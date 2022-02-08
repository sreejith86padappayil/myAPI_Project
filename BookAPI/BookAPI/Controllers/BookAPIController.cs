using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookAPI;
using System.Net;
using System.Net.Http;

namespace BookAPI.Controllers
{
    /// <summary>
    /// Book API Controller
    /// </summary>
    [Route("api/BookAPI")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        /// <summary>
        /// Book Catalog Service Repository
        /// </summary>
        private ICatalogRepository _bookService;

        /// <summary>
        /// String to hold the custom message
        /// </summary>
        private string status_message = string.Empty;

        /// <summary>
        /// To maintain the Status code of CRUD operations
        /// </summary>
        private int status_code;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="bookService">Book Catalog Service</param>
        public BookAPIController(ICatalogRepository bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Method to read all books;
        /// </summary>
        /// <returns>List of book catalogs</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var books = _bookService.GetAllBooks();
            
            if (books != null && books.Count() > 0)
            {
                status_message = "200 - Ok !!! Able to fetch book details successfully !!!";
                status_code = 200;
            }
            else
            {
                status_message = "400 Bad Request - Failed to fetch book details !!!";
                status_code = 400;
            }

            var response = new CreatedAtActionResult("Get-Complete Objects", "BookAPI", "", new
            {
                message = status_message,
                currentDate = DateTime.Now,
                StatusCode = status_code
            });
            return response;
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
                status_message = String.Format("200 - Ok !!! Book - {0} with ISBN {1} added successfully !!!", _title, _ISBN);
                status_code = 200;
            }
            else
            {
                status_message = String.Format("400 Bad Request - Failed to add the Book - {0} with ISBN {1} !!!", _title, _ISBN);
                status_code = 400;
            }

            var response = new CreatedAtActionResult("Add", "BookAPI", "", new
            {
                message = status_message,
                currentDate = DateTime.Now,
                StatusCode = status_code
            });
            return response;
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
                status_message = String.Format("200 - Ok !!! Book with ISBN {0} updated successfully !!!", _ISBN);
                status_code = 200;
            }
            else
            {
                status_message = String.Format("400 Bad Request - Failed to update the book ( ISBN - {0} ) !!!", _ISBN);
                status_code = 400;
            }

            var response = new CreatedAtActionResult("Update", "BookAPI", "", new
            {
                message = status_message,
                currentDate = DateTime.Now,
                StatusCode = status_code
            });
            return response;
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
                status_message = String.Format("200 - Ok !!! Book with ISBN {0} deleted successfully !!!", _ISBN);
                status_code = 200;
            }
            else
            {
                status_message = String.Format("400 Bad Request - Failed to delete the book ( ISBN - {0} ) !!!", _ISBN);
                status_code = 400;
            }
            var response = new CreatedAtActionResult("Delete", "BookAPI", "", new
            {
                message = status_message,
                currentDate = DateTime.Now,
                StatusCode = status_code
            });
            return response;
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

            if (books != null && books.Count() > 0)
            {
                status_message = String.Format("200 - Ok !!! Book with ISBN {0} able to find successfully !!!", _ISBN);
                status_code = 200;
            }
            else
            {
                status_message = String.Format("400 Bad Request - Failed to find any matches for ISBN - {0} !!!", _ISBN);
                status_code = 400;
            }

            var response = new CreatedAtActionResult("Get", "BookAPI", "", new
            {
                message = status_message,
                currentDate = DateTime.Now,
                StatusCode = status_code
            });
            return response;
        }
    }
}
