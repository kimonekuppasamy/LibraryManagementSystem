using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class LibraryManagementSystemContext : DbContext
    {
        public LibraryManagementSystemContext(DbContextOptions<LibraryManagementSystemContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Lender> Lenders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.ISBN)
                .IsUnique();

            modelBuilder.Entity<Lender>()
                .HasIndex(b => b.Email)
                .IsUnique();

            
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Lender)
                .WithMany(ld => ld.Loans)
                .HasForeignKey(l => l.LenderId)
                .OnDelete(DeleteBehavior.Cascade);


            // --- Seed Data ---

            // Books
            var book1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var book2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var book3Id = Guid.Parse("33333333-3333-3333-3333-333333333333");

            var lender1Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
            var lender2Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

            var loan1Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");
            var loan2Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = book1Id,
                    ISBN = "978-0140449136",
                    Title = "The Odyssey",
                    Author = "Homer",
                    PublishedYear = -800,
                    TotalCopies = 5,
                    CopiesAvailable = 5
                },
                new Book
                {
                    Id = book2Id,
                    ISBN = "978-0553212419",
                    Title = "Dracula",
                    Author = "Bram Stoker",
                    PublishedYear = 1897,
                    TotalCopies = 3,
                    CopiesAvailable = 3
                },
                new Book
                {
                    Id = book3Id,
                    ISBN = "978-0439139595",
                    Title = "Harry Potter and the Goblet of Fire",
                    Author = "J.K. Rowling",
                    PublishedYear = 2000,
                    TotalCopies = 4,
                    CopiesAvailable = 4
                }
            );

            // Lenders

            modelBuilder.Entity<Lender>().HasData(
                new Lender
                {
                    Id = lender1Id,
                    FullName = "Alice Johnson",
                    Email = "alice@example.com"
                },
                new Lender
                {
                    Id = lender2Id,
                    FullName = "Bob Smith",
                    Email = "bob@example.com"
                }
            );

            // Loans
            modelBuilder.Entity<Loan>().HasData(
                new Loan
                {
                    Id = loan1Id,
                    BookId = book1Id,
                    LenderId = lender1Id,
                    LoanDate = new DateTime(2025, 9, 20),
                    DueDate = new DateTime(2025, 9, 27),
                    ReturnDate = null  // overdue
                },
                new Loan
                {
                    Id = loan2Id,
                    BookId = book2Id,
                    LenderId = lender2Id,
                    LoanDate = new DateTime(2025, 9, 20),
                    DueDate = new DateTime(2025, 9, 27),
                    ReturnDate = null  // active
                }
            );
        }
    }
}
