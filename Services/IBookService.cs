using Gestor_Libros_EF.DTOs;

namespace Gestor_Libros_EF.Services
{
    public interface IBookService
    {
        Task<bool> AddBookAsync(BookDTO bookDto);
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDTO>> SearchBooksByTitleAsync(string title);
        Task<bool> UpdateBookAsync(BookDTO bookDto);
        Task<bool> DeleteBookAsync(int id);

    }
}
