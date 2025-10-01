using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

public static class DbInitializer
{
    public static void Initialize(LibraryManagementSystemContext context)
    {
        // Ensure database is created
        context.Database.EnsureCreated();

        // Seed Books
        if (!context.Books.Any())
        {
            var books = new List<Book>
            {
                new Book
                {
                    Id = Guid.NewGuid(),
                    ISBN = "978-0001",
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    PublishedYear = 1925,
                    TotalCopies = 5,
                    CopiesAvailable = 5
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    ISBN = "978-0002",
                    Title = "1984",
                    Author = "George Orwell",
                    PublishedYear = 1949,
                    TotalCopies = 3,
                    CopiesAvailable = 3
                }
            };
            context.Books.AddRange(books);
        }

        // Seed Lenders
        if (!context.Lenders.Any())
        {
            var lenders = new List<Lender>
            {
                new Lender
                {
                    Id = Guid.NewGuid(),
                    FullName = "Alice Johnson",
                    Email = "alice@example.com"
                },
                new Lender
                {
                    Id = Guid.NewGuid(),
                    FullName = "Bob Smith",
                    Email = "bob@example.com"
                }
            };
            context.Lenders.AddRange(lenders);
        }

        // Seed Loans
        if (!context.Loans.Any())
        {
            var firstBook = context.Books.FirstOrDefault();
            var firstLender = context.Lenders.FirstOrDefault();

            if (firstBook != null && firstLender != null)
            {
                var loans = new List<Loan>{
                    new Loan
                    {
                        Id = Guid.NewGuid(),
                        BookId = firstBook.Id,
                        LenderId = firstLender.Id,
                        LoanDate = DateTime.Now.AddDays(-3),
                        DueDate = DateTime.Now.AddDays(11),
                        ReturnDate = null
                    }
                };

                context.Loans.AddRange(loans);

                firstBook.CopiesAvailable--;
                context.Books.Update(firstBook);
            }
        }

        context.SaveChanges();
    }
}

