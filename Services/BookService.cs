using Gestor_Libros_EF.DTOs;
using Gestor_Libros_EF.Models;
using Gestor_Libros_EF.Repositories;

namespace Gestor_Libros_EF.Services
{
    public class BookService : IBookService
    {
        // Inyección de dependencias del repositorio
        private readonly IBookRepository _bookRepository;

        // Constructor para inyectar el repositorio
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> AddBookAsync(BookDTO bookDto)
        {
            var existingBooks = await _bookRepository.GetByTitleAsync(bookDto.Title);

            if (existingBooks.Any())
                return false;

            var book = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                Description = bookDto.Description,
                Genre = bookDto.Genre,
                YearPublished = bookDto.YearPublished
            };

            await _bookRepository.AddAsync(book);
            return true;
        }

        // 
        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            var books = await  _bookRepository.GetAllAsync();
            return books.Select(b => new BookDTO
            {
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                Genre = b.Genre,
                YearPublished = b.YearPublished
            });
        }     
     
        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return null;

            return new BookDTO
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Genre = book.Genre,
                YearPublished = book.YearPublished
            };
        }

        public async Task<IEnumerable<BookDTO>> SearchBooksByTitleAsync(string title)
        {
            var books = await _bookRepository.GetByTitleAsync(title);
            if (books == null) return null;

            return books.Select(b => new BookDTO
            {
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                Genre = b.Genre,
                YearPublished = b.YearPublished
            });
        }

        public async Task<bool> UpdateBookAsync(BookDTO bookDto)
        {
            var  book = await _bookRepository.GetByIdAsync(bookDto.Id);
            if (book == null) return false;

            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.Description = bookDto.Description;
            book.Genre = bookDto.Genre;
            book.YearPublished = bookDto.YearPublished;

            await  _bookRepository.UpdateAsync(book);
            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var boot = await _bookRepository.GetByIdAsync(id);
            if (boot == null) return false;

            await _bookRepository.DeleteAsync(id);
            return true;
        }
    }
}
