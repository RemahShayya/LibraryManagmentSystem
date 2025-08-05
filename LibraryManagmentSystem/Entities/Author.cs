namespace LibraryManagmentSystem.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Country { get; set; }

        public Book? Book { get; set; }
    }
}
