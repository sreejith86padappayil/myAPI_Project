using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookAPI;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        private ICatalogRepository _bookService;

        public BookAPIController(ICatalogRepository bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Method to read all books;
        /// </summary>
        /// <returns>List of book catalogs</returns>
        [HttpGet]
        public IActionResult ReadAll()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        /// <summary>
        /// Method to add a book catalog
        /// </summary>
        /// <param name="_title">Book title</param>
        /// <param name="_author">Book author</param>
        /// <param name="_co_author">Book co-author</param>
        /// <param name="_ISBN">Book ISBN</param>
        /// <param name="_publishedDate">Book published date</param>
        /// <returns>Book addition status</returns>
        [HttpPost]
        public IActionResult Add(string _title, string _author, string _co_author, string _ISBN, DateOnly _publishedDate)
        {
            var result = _bookService.AddBook(_title, _author, _co_author, _ISBN, _publishedDate);
            if (result == true)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Method to update a book catalog
        /// </summary>
        /// <param name="_title">Book title</param>
        /// <param name="_author">Book author</param>
        /// <param name="_co_author">Book co-author</param>
        /// <param name="_ISBN">Book ISBN</param>
        /// <param name="_publishedDate">Book published date</param>
        /// <returns>Book updation status</returns>
        [HttpPut]
        public IActionResult Update(string _title, string _author, string _co_author, string _ISBN, DateOnly _publishedDate)
        {
            var update_status = _bookService.UpdateBook(_title, _author, _co_author, _ISBN, _publishedDate);
            if (update_status == true)
            {
                return Ok(update_status);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Method to delete a book catalog
        /// </summary>
        /// <param name="_ISBN">Book ISBN</param>
        /// <returns>Book deletion status</returns>
        [HttpDelete]
        public IActionResult Delete(string _ISBN)
        {
            var delete_status = _bookService.DeleteBook(_ISBN);
            if (delete_status == true)
            {
                return Ok(delete_status);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Method to search a book catalog
        /// </summary>
        /// <param name="_title">Book title</param>
        /// <param name="_author">Book author, or co-author name</param>
        /// <param name="_ISBN">Book ISBN</param>
        /// <returns>Search result</returns>
        [HttpGet]
        public IActionResult Get(string _title, string _author, string _ISBN)
        {
            var books = _bookService.SearchBooks(_title, _author, _ISBN);
            return Ok(books);
        }
    }
}
