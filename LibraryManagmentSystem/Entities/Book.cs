using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagmentSystem.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }

        public Author? Author { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }

        public Publisher? Publisher { get; set; }
        [ForeignKey("PublisherId")]
        public int PublisherId { get; set; }

        public List<BookCategory>? BookCategories { get; set; }
    }
}
