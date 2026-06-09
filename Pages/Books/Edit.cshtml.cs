using Gestor_Libros_EF.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gestor_Libros_EF.Pages.Books;

public class EditModel(IHttpClientFactory httpClientFactory) : PageModel
{
    [BindProperty]
    public BookDTO Book { get; set; } = new();
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var client = httpClientFactory.CreateClient("BooksApi");
        var response = await client.GetAsync($"api/book/{id}");
        if (!response.IsSuccessStatusCode) return NotFound();
        Book = await response.Content.ReadFromJsonAsync<BookDTO>() ?? new();
        
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var client = httpClientFactory.CreateClient("BooksApi");
        var response = await client.PutAsJsonAsync($"api/book/{Book.Id}", Book);

        if (response.IsSuccessStatusCode) return RedirectToPage("Index");

        ErrorMessage = "Error al actualizar el libro.";
        return Page();
    }
}
