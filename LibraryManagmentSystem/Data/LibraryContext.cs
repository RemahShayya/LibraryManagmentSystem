using LibraryManagmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagmentSystem.Data
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithOne(a => a.Book)
                .HasForeignKey<Book>(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(b => b.Title).IsRequired();
                entity.Property(b => b.Description).IsRequired();
                entity.Property(b => b.Price).IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.Name);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(a => a.FirstName).IsRequired();
                entity.Property(a => a.LastName).IsRequired();
                entity.Property(a => a.Country);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(p => p.Name).IsRequired();
                entity.Property(p => p.Location).IsRequired();
            });
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
    }
}
