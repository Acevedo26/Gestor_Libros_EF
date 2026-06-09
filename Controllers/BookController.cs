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
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        // GET: api/book/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        //GET: api/book/search?title=algo
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> SearchBooks([FromQuery] string title)
        {
            var books = await _bookService.SearchBooksByTitleAsync(title);
            return Ok(books);
        }

        // POST: api/Book
        [HttpPost]
        public async Task<ActionResult> AddBook([FromBody] BookDTO bookDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await  _bookService.AddBookAsync(bookDTO);
            return CreatedAtAction(nameof(GetBookById), new { id = bookDTO.Id }, bookDTO);

        }

        // PUT: api/book/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] BookDTO bookDTO)
        {
            if(id != bookDTO.Id) 
                return BadRequest("ID de libro no coincide");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _bookService.UpdateBookAsync(bookDTO);
            if (!updated)
                return NotFound("Libro no encontrado");
            return NoContent();
        }

        // DELETE: api/book/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var deleted = await _bookService.DeleteBookAsync(id);
            if (!deleted)
                return NotFound("Libro no encontrado");
            return NoContent();
        }

        
    }
}
