using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Interfaces;

public interface ILoanManager
{
    bool BorrowBook(int memberNumber, string isbn, int loanPeriodDays);

    bool ReturnBook(int memberNumber, string isbn);

    List<Book> GetBorrowedBooks();

    bool IsBookAvailable(string isbn);
    
    bool IsBookBorrowed(string isbn);
}
