namespace BookAPI
{

    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Book Catalog model
    /// </summary>
    public class BookCatalog
    {
        /// <summary>
        /// Represent the Book title.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Refer the Primary author name.
        /// </summary>
        [Required]
        public string Author { get; set; }

        /// <summary>
        /// Refer the co-author name.
        /// </summary>
        public string? CoAuthor { get; set; }

        /// <summary>
        /// Refer the ISBN number of 13 digits.
        /// </summary>
        [RegularExpression(@"([0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*)", ErrorMessage = "Please enter a 13 digit valid ISBN.")]
        [Required]
        public string ISBN { get; set; }

        /// <summary>
        /// Refer the published date of the book.
        /// </summary>
        [Required]
        public DateOnly PublishedDate { get; set; }
    }
}
