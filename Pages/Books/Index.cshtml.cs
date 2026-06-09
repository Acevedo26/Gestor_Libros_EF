using Gestor_Libros_EF.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gestor_Libros_EF.Pages.Books;

public class IndexModel(IHttpClientFactory httpClientFactory) : PageModel
{
    public List<BookDTO> Books { get; set; } = [];
    public string? SearchTitle { get; set; }

    public async Task OnGetAsync(string? title)
    {
        SearchTitle = title;
        var client = httpClientFactory.CreateClient("BooksApi");
        var url = string.IsNullOrWhiteSpace(title) ? "api/book" : $"api/book/search?title={Uri.EscapeDataString(title)}";
        Books = await client.GetFromJsonAsync<List<BookDTO>>(url) ?? [];
    }
}
