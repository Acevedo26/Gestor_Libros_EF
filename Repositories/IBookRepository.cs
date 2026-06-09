
using Gestor_Libros_EF.Models;

namespace Gestor_Libros_EF.Repositories
{
    public interface IBookRepository
    {
        Task AddAsync(Book book);
        Task<IEnumerable<Book>> GetAllAsync(); 
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetByTitleAsync(string title);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);

    }
}
