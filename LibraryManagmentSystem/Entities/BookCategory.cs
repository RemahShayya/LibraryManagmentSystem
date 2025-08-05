using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagmentSystem.Entities
{
    public class BookCategory
    {
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public Book? Book { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
