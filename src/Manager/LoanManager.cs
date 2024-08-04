using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez;

public class LoanManager : ILoanManager
{
    private readonly IDataManager<Book> _bookDataManager;
    private readonly IDataManager<User> _userDataManager;
    private readonly IDataManager<Loan> _presentLoans;

    private readonly IDataManager<Loan> _loansHistory;

    public LoanManager(IDataManager<Book> bookDataManager, IDataManager<User> userDataManager, IDataManager<Loan> presentLoans, IDataManager<Loan> loansHistory)
    {
        _bookDataManager = bookDataManager;
        _userDataManager = userDataManager;
        _presentLoans = presentLoans;
        _loansHistory = loansHistory;
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

        var presentLoans = _presentLoans.LoadData();
        var loansHistory = _loansHistory.LoadData();
        var existingPresentLoan = presentLoans.FirstOrDefault(l => l.Borrower.MemberNumber == memberNumber);
        var existingLoansHistory = loansHistory.FirstOrDefault(l => l.Borrower.MemberNumber == memberNumber);

        if (existingPresentLoan != null || existingLoansHistory != null)
        {
            existingPresentLoan.BooksLoan.Add(new BookLoan
            {
                BookBorrow = book,
                BorrowDate = DateTime.Now,
                BorrowDueDate = DateTime.Now.AddDays(loanPeriodDays)
            });
            existingLoansHistory.BooksLoan.Add(new BookLoan
            {
                BookBorrow = book,
                BorrowDate = DateTime.Now,
                BorrowDueDate = DateTime.Now.AddDays(loanPeriodDays)
            });
            _presentLoans.UpdateItem("LoanId", existingPresentLoan.LoanId, existingPresentLoan);
            _loansHistory.UpdateItem("LoanId", existingLoansHistory.LoanId, existingLoansHistory);
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
            _presentLoans.AddItem(newLoan);
            _loansHistory.AddItem(newLoan);
        }

        book.IsAvailable = false;
        _bookDataManager.UpdateItem("Isbn", isbn, book);
        presentLoans = _presentLoans.LoadData();
        loansHistory = _loansHistory.LoadData();
        //loans = _loanDataManager.LoadData();
        var updatedPresentLoan = presentLoans.FirstOrDefault(l => l.Borrower.MemberNumber == memberNumber);
        var updatedLoansHistory = loansHistory.FirstOrDefault(l => l.Borrower.MemberNumber == memberNumber);
        if (updatedPresentLoan != null || updatedLoansHistory != null)
        {
            foreach (var bookLoan in updatedPresentLoan.BooksLoan)
            {
                if (bookLoan.BookBorrow.Isbn == isbn)
                {
                    bookLoan.BookBorrow.IsAvailable = false;
                }
            }
            foreach (var bookLoan in updatedLoansHistory.BooksLoan)
            {
                if (bookLoan.BookBorrow.Isbn == isbn)
                {
                    bookLoan.BookBorrow.IsAvailable = false;
                }
            }
            _presentLoans.UpdateItem("LoanId", updatedPresentLoan.LoanId, updatedPresentLoan);
            _loansHistory.UpdateItem("LoanId", updatedLoansHistory.LoanId, updatedLoansHistory);
        }

        return true;
    }

    public List<Book> GetBorrowedBooks()
    {
        var loans = _presentLoans.LoadData();
        return loans.SelectMany(l => l.BooksLoan.Select(bl => bl.BookBorrow)).ToList();
    }

    public bool IsBookAvailable(string isbn)
    {
        var book = _bookDataManager.SearchById("Isbn", isbn);
        return book != null && book.IsAvailable;
    }

    public bool IsBookBorrowed(string isbn)
    {
        var loans = _presentLoans.LoadData();
        return loans.Any(l => l.BooksLoan.Any(bl => bl.BookBorrow.Isbn == isbn));
    }

    public bool ReturnBook(int memberNumber, string isbn)
    {
        var loans = _presentLoans.LoadData();
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
            _presentLoans.UpdateItem("LoanId", loan.LoanId, loan);
        }
        else
        {
            _presentLoans.RemoveItem("LoanId", loan.LoanId);
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
