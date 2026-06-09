using Gestor_Libros_EF.Data;
using Gestor_Libros_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestor_Libros_EF.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        // Constructor de inyección de dependencias
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        // Implementación de métodos CRUD

        // Agrega un nuevo libro a la base de datos
        public async Task AddAsync(Book book)
        {
             await _context.Books.AddAsync(book);
             await _context.SaveChangesAsync();    
        }

        // Obtiene todos los libros de la base de datos
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        // Obtiene un libro por su ID
        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        // Obtiene libros por título
        public async Task<IEnumerable<Book>> GetByTitleAsync(string title)
        {
            return await _context.Books
                .Where(b => b.Title.Contains(title))
                .ToListAsync();  
        }

        // Actualiza un libro existente en la base de datos
        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        // Elimina un libro de la base de datos por su ID
        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
