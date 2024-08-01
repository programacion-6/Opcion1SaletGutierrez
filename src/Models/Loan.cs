namespace Opcion1SaletGutierrez.src.Models;

public class Loan
{
    public List<Book> BorrowedBook { get; set; }

    public User Borrower { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime BorrowDueDate { get; set; }
}
