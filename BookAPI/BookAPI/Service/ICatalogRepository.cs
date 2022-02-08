namespace BookAPI
{
    /// <summary>
    /// Contract class with CRUD operations.
    /// </summary>
    public interface ICatalogRepository
    {
        /// <summary>
        /// Return the list of all the book catalogs
        /// </summary>
        /// <returns>List of Book Catalog objects</returns>
        IEnumerable<BookCatalog> GetAllBooks();

        /// <summary>
        /// Method to add a book catalog
        /// </summary>
        /// <param name="_title">Title of the book</param>
        /// <param name="_author">Book author</param>
        /// <param name="_co_author">Book co-author</param>
        /// <param name="_ISBN">Book ISBN</param>
        /// <param name="_publishedDate">Book published date</param>
        /// <returns>Addition status</returns>
        bool AddBook(string _title, string _author, string _co_author, string _ISBN, DateOnly _publishedDate);

        /// <summary>
        /// To update a book catalog
        /// </summary>
        /// <param name="_title">Title of the book</param>
        /// <param name="_author">Book author</param>
        /// <param name="_co_author">Book co-author</param>
        /// <param name="_ISBN">Book ISBN</param>
        /// <param name="_publishedDate">Book published date</param>
        /// <returns>Update status</returns>
        bool UpdateBook(string _title, string _author, string _co_author, string _ISBN, DateOnly _publishedDate);

        /// <summary>
        /// Method to delete a book catalog
        /// </summary>
        /// <param name="_ISBN">Book catalog's ISBN to delete</param>
        /// <returns>Deletion status</returns>
        bool DeleteBook(string _ISBN);

        /// <summary>
        /// To add a book catalog
        /// </summary>
        /// <param name="catalog">Book catalog object</param>
        /// <returns>Return the new catalog object added</returns>
        BookCatalog AddBook(BookCatalog catalog);

        /// <summary>
        /// To search book catalogs using title or author name or by ISBN
        /// </summary>
        /// <param name="_title">Book title</param>
        /// <param name="_author">Author or Co-author name</param>
        /// <param name="_ISBN">ISBN number</param>
        /// <returns>List of matching book catalogs</returns>
        IEnumerable<BookCatalog> SearchBooks(string _title, string _author, string _ISBN);

    }
}
