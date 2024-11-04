using Microsoft.AspNetCore.Mvc;
using Model;
using System.Collections.Generic;

namespace Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookManager _bookManager;

        public BooksController()
        {
            _bookManager = new BookManager();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(_bookManager.GetAllBooks());
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _bookManager.GetBookById(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> AddBook([FromBody] Book book)
        {
            _bookManager.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.Id)
                return BadRequest();

            _bookManager.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            _bookManager.DeleteBook(id);
            return NoContent();
        }
    }
}
