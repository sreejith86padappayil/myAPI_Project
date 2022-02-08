namespace BookAPI
{
    /// <summary>
    /// Service class which implemeents the Book catalog operations
    /// </summary>
    public class CatalogRepository : ICatalogRepository
    {
        /// <summary>
        /// List of Book Catalog objects
        /// </summary>
        private List<BookCatalog> bookCatalogs = new List<BookCatalog>();

        /// <summary>
        /// Constructor to initialize the default list of objects.
        /// </summary>
        public CatalogRepository()
        {
            AddBook(new BookCatalog { Title = "Half girlfriend", Author = "Chetan Bhagat", ISBN = "978-8129135728", PublishedDate = new DateOnly(2014, 10, 01) });
            AddBook(new BookCatalog { Title = "Wings of fire", Author = "A. P. J. Abdul Kalam", ISBN = "978-8174341440", PublishedDate = new DateOnly(2009, 07, 15) });
            AddBook(new BookCatalog { Title = "The Invisible Man", Author = "H.G. Wells", ISBN = "978-8175994324", PublishedDate = new DateOnly(2017, 02, 01) });
            AddBook(new BookCatalog { Title = "A Full Life", Author = "Sabira Merchant", ISBN = "978-9390166862", PublishedDate = new DateOnly(2022, 02, 02) });
        }

        /// <summary>
        /// Method to add a book catalog
        /// </summary>
        /// <param name="_title">Title of the book</param>
        /// <param name="_author">Book author</param>
        /// <param name="_co_author">Book co-author</param>
        /// <param name="_ISBN">Book ISBN</param>
        /// <param name="_publishedDate">Book published date</param>
        /// <returns>Addition status</returns>
        public bool AddBook(string _title, string _author, string _co_author, string _ISBN, DateOnly _publishedDate)
        {
            bool add_status = false;
            BookCatalog book_added;
            BookCatalog book = new BookCatalog { Title = _title, Author = _author, CoAuthor = _co_author, ISBN = _ISBN, PublishedDate = _publishedDate };
            book_added = AddBook(book);
            if(book_added != null && !string.IsNullOrWhiteSpace(book_added.ISBN))
            {
                add_status = true;
            }
            return add_status;
        }

        /// <summary>
        /// Method to add a book catalog.
        /// </summary>
        /// <param name="catalog">Book catalog to add</param>
        /// <returns>Added book catalog object</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public BookCatalog AddBook(BookCatalog catalog)
        {
            string catalog_ISBN = string.Empty;
            BookCatalog return_Catalog = new BookCatalog();

            if (catalog == null)
            {
                return new BookCatalog();
            }
            else
            {
                bookCatalogs.Add(catalog);
                catalog_ISBN = catalog.ISBN;
                return_Catalog = bookCatalogs.Find(item => item.ISBN == catalog_ISBN);
                if (string.IsNullOrWhiteSpace(return_Catalog.ISBN))
                {
                    return new BookCatalog();
                }
                else
                {
                    return return_Catalog;
                }
            }
        }

        /// <summary>
        /// Method to delete a book catalog
        /// </summary>
        /// <param name="_ISBN">Book catalog's ISBN to delete</param>
        /// <returns>Deletion status</returns>
        public bool DeleteBook(string _ISBN)
        {
            bool is_deleted = false;
            string book_ISBN = string.Empty;
            BookCatalog findObject = new BookCatalog();
            if (_ISBN != null && !string.IsNullOrWhiteSpace(_ISBN))
            {
                book_ISBN = _ISBN;
                if (bookCatalogs != null)
                {
                    findObject = bookCatalogs.Find(item => item.ISBN == book_ISBN);
                    if (!string.IsNullOrWhiteSpace(findObject.ISBN))
                    {
                        is_deleted = bookCatalogs.Remove(findObject);
                    }
                    return is_deleted;
                }
                else
                {
                    return is_deleted;
                }
            }
            else
            {
                return is_deleted;
            }
        }

        /// <summary>
        /// To return all the list of Book catalogs
        /// </summary>
        /// <returns>List of book catalog objects</returns>
        public IEnumerable<BookCatalog> GetAllBooks()
        {
            if (bookCatalogs != null)
            {
                return bookCatalogs;
            }
            else
            {
                return new List<BookCatalog>();
            }
        }

        /// <summary>
        /// Method to implement the search feature of book catalogs;
        /// </summary>
        /// <param name="_title">Book title</param>
        /// <param name="_author">Book author name</param>
        /// <param name="_ISBN">Book ISBN No.</param>
        /// <returns>Return the list of matching book catalogs</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<BookCatalog> SearchBooks(string _title, string _author, string _ISBN)
        {
            List<BookCatalog> matchingCatalogs = new List<BookCatalog>();
            if (!string.IsNullOrWhiteSpace(_title) || !string.IsNullOrWhiteSpace(_author) || !string.IsNullOrWhiteSpace(_ISBN))
            {
                matchingCatalogs = bookCatalogs.FindAll(item => item.Title == _title || item.Author == _author ||
                item.CoAuthor == _author || item.ISBN == _ISBN);
            }
            return matchingCatalogs;
        }

        /// <summary>
        /// To update a book catalog
        /// </summary>
        /// <param name="_title">Title of the book</param>
        /// <param name="_author">Book author</param>
        /// <param name="_co_author">Book co-author</param>
        /// <param name="_ISBN">Book ISBN</param>
        /// <param name="_publishedDate">Book published date</param>
        /// <returns>Update status</returns>
        public bool UpdateBook(string _title, string _author, string _co_author, string _ISBN, DateOnly _publishedDate)
        {
            bool is_updated = false;
            string book_ISBN = string.Empty;
            BookCatalog? findObject = new BookCatalog();
            BookCatalog? replaceObject = new BookCatalog();

            if (!string.IsNullOrWhiteSpace(_title) || !string.IsNullOrWhiteSpace(_author) ||
                     !string.IsNullOrWhiteSpace(_co_author) || !string.IsNullOrWhiteSpace(_ISBN) ||
                     !string.IsNullOrWhiteSpace(_publishedDate.ToString()))
            {
                if (!string.IsNullOrWhiteSpace(_ISBN))
                {
                    replaceObject = bookCatalogs.Find(item => item.ISBN == _ISBN);
                    if (replaceObject != null && !string.IsNullOrWhiteSpace(replaceObject.ISBN))
                    {
                        findObject = replaceObject;
                        bookCatalogs.Remove(replaceObject);
                        findObject.Title = !string.IsNullOrWhiteSpace(_title) ? _title : findObject.Title;
                        findObject.Author = !string.IsNullOrWhiteSpace(_author) ? _author : findObject.Author;
                        findObject.CoAuthor = !string.IsNullOrWhiteSpace(_co_author) ? _co_author : findObject.CoAuthor;
                        findObject.ISBN = !string.IsNullOrWhiteSpace(_ISBN) ? _ISBN : findObject.ISBN;
                        findObject.PublishedDate = !string.IsNullOrWhiteSpace(_publishedDate.ToString()) ? _publishedDate : findObject.PublishedDate;
                        bookCatalogs.Add(findObject);
                        is_updated = true;
                    }
                }
                return is_updated;
            }
            else
            {
                return is_updated;
            }
        }

    }
}
