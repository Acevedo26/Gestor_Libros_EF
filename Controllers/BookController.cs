using Gestor_Libros_EF.DTOs;
using Gestor_Libros_EF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_Libros_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // Inyección de dependencia del servicio de libros
        private readonly IBookService _bookService;


        // Constructor que recibe el servicio de libros como parámetro
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetAllBooks()
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los libros: {ex.Message}");
            }
        }

        // GET: api/book/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBookById(int id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);
                if (book == null)
                    return NotFound($"Libro con ID {id} no encontrado.");
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el libro: {ex.Message}");
            }
        }

        // GET: api/book/search?title=algo
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> SearchBooks([FromQuery] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return BadRequest("El parámetro 'title' es requerido.");
            try
            {
                var books = await _bookService.SearchBooksByTitleAsync(title);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar libros: {ex.Message}");
            }
        }

        // POST: api/Book
        [HttpPost]
        public async Task<ActionResult> AddBook([FromBody] BookDTO bookDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var added = await _bookService.AddBookAsync(bookDTO);
                if (!added)
                    return Conflict("Ya existe un libro con ese título.");
                return CreatedAtAction(nameof(GetBookById), new { id = bookDTO.Id }, bookDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar el libro: {ex.Message}");
            }
        }

        // PUT: api/book/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] BookDTO bookDTO)
        {
            if (id != bookDTO.Id)
                return BadRequest("El ID de la ruta no coincide con el ID del libro.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var updated = await _bookService.UpdateBookAsync(bookDTO);
                if (!updated)
                    return NotFound($"Libro con ID {id} no encontrado.");
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el libro: {ex.Message}");
            }
        }

        // DELETE: api/book/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            try
            {
                var deleted = await _bookService.DeleteBookAsync(id);
                if (!deleted)
                    return NotFound($"Libro con ID {id} no encontrado.");
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el libro: {ex.Message}");
            }
        }

        
    }
}
