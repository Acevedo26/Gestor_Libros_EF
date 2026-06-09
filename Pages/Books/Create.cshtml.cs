using Gestor_Libros_EF.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gestor_Libros_EF.Pages.Books;

public class CreateModel(IHttpClientFactory httpClientFactory) : PageModel
{
    [BindProperty]
    public BookDTO Book { get; set; } = new();
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var client = httpClientFactory.CreateClient("BooksApi");
        var response = await client.PostAsJsonAsync("api/book", Book);

        if (response.IsSuccessStatusCode) return RedirectToPage("Index");

        ErrorMessage = response.StatusCode == System.Net.HttpStatusCode.Conflict
            ? "Ya existe un libro con ese título."
            : "Error al guardar el libro.";
        return Page();
    }
}
