using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez;

public class LoanManager : ILoanManager
{
    private readonly IDataManager<Book> _bookDataManager;
    private readonly IDataManager<User> _userDataManager;
    private readonly IDataManager<Loan> _loanDataManager;

    public LoanManager(IDataManager<Book> bookDataManager, IDataManager<User> userDataManager, IDataManager<Loan> loanDataManager)
    {
        _bookDataManager = bookDataManager;
        _userDataManager = userDataManager;
        _loanDataManager = loanDataManager;
    }

    public bool BorrowBook(int memberNumber, string isbn, int loanPeriodDays)
    {
        var user = _userDataManager.SearchById("MemberNumber", memberNumber);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return false;
        }

        var book = _bookDataManager.SearchById("Isbn", isbn);
        if (book == null || !book.IsAvailable)
        {
            Console.WriteLine("Book not available.");
            return false;
        }

        var loans = _loanDataManager.LoadData();
        var existingLoan = loans.FirstOrDefault(l => l.Borrower.MemberNumber == memberNumber);

        if (existingLoan != null)
        {
            existingLoan.BooksLoan.Add(new BookLoan
            {
                BookBorrow = book,
                BorrowDate = DateTime.Now,
                BorrowDueDate = DateTime.Now.AddDays(loanPeriodDays)
            });
            _loanDataManager.UpdateItem("LoanId", existingLoan.LoanId, existingLoan);
        }
        else
        {
            var newLoan = new Loan
            {
                LoanId = Guid.NewGuid(),
                Borrower = user,
                BooksLoan = new List<BookLoan>
            {
                new BookLoan
                {
                    BookBorrow = book,
                    BorrowDate = DateTime.Now,
                    BorrowDueDate = DateTime.Now.AddDays(loanPeriodDays)
                }
            }
            };
            _loanDataManager.AddItem(newLoan);
        }

        book.IsAvailable = false;
        _bookDataManager.UpdateItem("Isbn", isbn, book);
        loans = _loanDataManager.LoadData();
        var updatedLoan = loans.FirstOrDefault(l => l.Borrower.MemberNumber == memberNumber);
        if (updatedLoan != null)
        {
            foreach (var bookLoan in updatedLoan.BooksLoan)
            {
                if (bookLoan.BookBorrow.Isbn == isbn)
                {
                    bookLoan.BookBorrow.IsAvailable = false;
                }
            }
            _loanDataManager.UpdateItem("LoanId", updatedLoan.LoanId, updatedLoan);
        }

        return true;
    }

    public List<Book> GetBorrowedBooks()
    {
        var loans = _loanDataManager.LoadData();
        return loans.SelectMany(l => l.BooksLoan.Select(bl => bl.BookBorrow)).ToList();
    }

    public bool IsBookAvailable(string isbn)
    {
        var book = _bookDataManager.SearchById("Isbn", isbn);
        return book != null && book.IsAvailable;
    }

    public bool IsBookBorrowed(string isbn)
    {
        var loans = _loanDataManager.LoadData();
        return loans.Any(l => l.BooksLoan.Any(bl => bl.BookBorrow.Isbn == isbn));
    }

    public bool ReturnBook(int memberNumber, string isbn)
    {
        var loans = _loanDataManager.LoadData();
        var loan = loans.FirstOrDefault(l => l.Borrower.MemberNumber == memberNumber);

        if (loan == null)
        {
            Console.WriteLine("No loan found for this user.");
            return false;
        }

        var bookLoan = loan.BooksLoan.FirstOrDefault(bl => bl.BookBorrow.Isbn == isbn);
        if (bookLoan == null)
        {
            Console.WriteLine("This book is not borrowed by the user.");
            return false;
        }

        loan.BooksLoan.Remove(bookLoan);

        if (loan.BooksLoan.Count > 0)
        {
            _loanDataManager.UpdateItem("LoanId", loan.LoanId, loan);
        }
        else
        {
            _loanDataManager.RemoveItem("LoanId", loan.LoanId);
        }

        var book = _bookDataManager.SearchById("Isbn", isbn);
        if (book != null)
        {
            book.IsAvailable = true;
            _bookDataManager.UpdateItem("Isbn", isbn, book);
        }

        return true;
    }
}
