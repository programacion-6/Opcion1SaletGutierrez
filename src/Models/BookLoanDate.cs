namespace Opcion1SaletGutierrez.src.Models;

public class BookLoan
{
    public Book BookBorrow { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime BorrowDueDate { get; set; }
}
