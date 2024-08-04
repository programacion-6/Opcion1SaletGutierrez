namespace Opcion1SaletGutierrez.src.Models;

public class Loan
{
    public Guid LoanId { get; set; }

    public List<BookLoan> BooksLoan { get; set; }

    public User Borrower { get; set; }
}
