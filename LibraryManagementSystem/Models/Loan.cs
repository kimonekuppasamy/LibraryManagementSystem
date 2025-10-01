using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Loan
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid LenderId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Book? Book { get; set; }
        public Lender? Lender { get; set; }
    }
}
