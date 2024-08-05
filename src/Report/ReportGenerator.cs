using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Report;

public class ReportGenerator
{
    private readonly IDataManager<Loan> _loanDataManager;
    private readonly IDataManager<Loan> _loansHistory;

    public ReportGenerator(IDataManager<Loan> loanDataManager, IDataManager<Loan> loansHistory)
    {
        _loanDataManager = loanDataManager;
        _loansHistory = loansHistory;
    }

    public void PrintAllBorrowedBooks()
    {
        var loans = _loanDataManager.LoadData();
        var borrowedBooks = loans.SelectMany(l => l.BooksLoan)
                            .Select(bl => bl.BookBorrow).Distinct().ToList();

        Console.WriteLine("All Borrowed Books:");
        foreach (var book in borrowedBooks)
        {
            var bookLoan = loans.SelectMany(l => l.BooksLoan)
                            .FirstOrDefault(bl => bl.BookBorrow.Isbn == book.Isbn);
            if (bookLoan != null)
            {
                Console.WriteLine($"- ISBN: {book.Isbn}, Title: {book.Title}, Borrowed Date: {bookLoan.BorrowDate.ToShortDateString()}, Due Date: {bookLoan.BorrowDueDate.ToShortDateString()}");
            }
        }
    }

    public void PrintOverdueBooks()
    {
        var loans = _loanDataManager.LoadData();
        var overdueBooks = loans
            .SelectMany(l => l.BooksLoan)
            .Where(bl => bl.BorrowDueDate < DateTime.Now)
            .Select(bl => bl.BookBorrow)
            .Distinct()
            .ToList();

        Console.WriteLine("Overdue Books:");
        foreach (var book in overdueBooks)
        {
            var bookLoan = loans.SelectMany(l => l.BooksLoan)
                            .FirstOrDefault(bl => bl.BookBorrow.Isbn == book.Isbn);
            if (bookLoan != null)
            {
                Console.WriteLine($"- ISBN: {book.Isbn}, Title: {book.Title}, Due Date: {bookLoan.BorrowDueDate.ToShortDateString()}");
            }
        }
    }

    public void PrintUserLoanHistory(int memberNumber)
    {
        var loans = _loansHistory.LoadData();
        var userLoan = loans.FirstOrDefault(l => l.Borrower.MemberNumber == memberNumber);

        if (userLoan == null)
        {
            Console.WriteLine("No loan history found for this user.");
            return;
        }

        Console.WriteLine($"Loan History for Member Number: {memberNumber}");
        foreach (var bookLoan in userLoan.BooksLoan)
        {
            Console.WriteLine($"- ISBN: {bookLoan.BookBorrow.Isbn}, Title: {bookLoan.BookBorrow.Title}, Borrow Date: {bookLoan.BorrowDate.ToShortDateString()}, Due Date: {bookLoan.BorrowDueDate.ToShortDateString()}");
        }
    }
}
