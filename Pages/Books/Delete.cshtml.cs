using Gestor_Libros_EF.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gestor_Libros_EF.Pages.Books;

public class DeleteModel(IHttpClientFactory httpClientFactory) : PageModel
{
    public BookDTO? Book { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var client = httpClientFactory.CreateClient("BooksApi");
        var response = await client.GetAsync($"api/book/{id}");
        if (!response.IsSuccessStatusCode) return NotFound();
        Book = await response.Content.ReadFromJsonAsync<BookDTO>();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var client = httpClientFactory.CreateClient("BooksApi");
        await client.DeleteAsync($"api/book/{id}");
        return RedirectToPage("Index");
    }
}
