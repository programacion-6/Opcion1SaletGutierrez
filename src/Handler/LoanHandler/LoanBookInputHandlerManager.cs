using Opcion1SaletGutierrez.src.Handler;
using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Manager;
using Opcion1SaletGutierrez.src.Models;
using Opcion1SaletGutierrez.src.Report;

namespace Opcion1SaletGutierrez;

public class LoanBookInputHandlerManager
{

    private string jsonFilePathBook = "src/Jsons/books.json";
    private string jsonFilePathUser = "src/Jsons/users.json";
    private string jsonFilePathPresentLoan = "src/Jsons/presentLoans.json";

    private string jsonFilePathLoadHistory = "src/Jsons/loansHistory.json";
    

    private readonly IDataManager<Book> _bookDataManager;
    private readonly IDataManager<User> _userDataManager;
    private readonly IDataManager<Loan> _presentLoans;

    private readonly IDataManager<Loan> _loansHistory;

    private readonly ILoanManager _loanManager;
    private readonly UserInputHandler userInputHandler;
    private readonly ReportGenerator _reportGenerator;

    public LoanBookInputHandlerManager()
    {
        _bookDataManager = new DataManager<Book>(jsonFilePathBook);
        _userDataManager = new DataManager<User>(jsonFilePathUser);
        _presentLoans = new DataManager<Loan>(jsonFilePathPresentLoan);
        _loansHistory = new DataManager<Loan>(jsonFilePathLoadHistory);
        _loanManager = new LoanManager(_bookDataManager, _userDataManager, _presentLoans, _loansHistory);
        userInputHandler = new UserInputHandler();
        _reportGenerator = new ReportGenerator(_presentLoans, _loansHistory);
    }

    public void ExecuteBorrowBookOption()
    {
        int memberNumber = userInputHandler.GetValidIntInput("Membership Number(21321312)");
        string isbn = userInputHandler.GetInput("Enter the ISBN of the book you want to rent: (i.e.: 978-987-25620-2-1):");
        int dueDate = userInputHandler.GetValidIntInput("Enter a Loan Time Period:");
        bool loanSuccessful =  _loanManager.BorrowBook(memberNumber, isbn, dueDate);
        Console.WriteLine(loanSuccessful ? "El libro ha sido prestado exitosamente." : "No se pudo realizar el préstamo. Verifique los datos ingresados y la disponibilidad del libro.");

    }

    public void ExecuteReturnBookOption()
    {
        int memberNumber = userInputHandler.GetValidIntInput("Membership Number(21321312)");
        string isbn = userInputHandler.GetInput("Enter the ISBN of the book you want to rent: (i.e.: 978-987-25620-2-1):");
        bool returnSuccessful = _loanManager.ReturnBook(memberNumber, isbn);
        Console.WriteLine(returnSuccessful ? "El libro ha sido devuelto exitosamente." : "No se pudo realizar la devolución. Verifique los datos ingresados.");

    }

    public void ExecuteIsBookAvailable()
    {
        string isbn = userInputHandler.GetInput("Enter the ISBN of the book you want to rent: (i.e.: 978-987-25620-2-1):");
        bool isAvailable = _loanManager.IsBookAvailable(isbn);
        Console.WriteLine(isAvailable ? "El libro está disponible." : "El libro no está disponible.");
    }

    public void ExecutelistOfBooksCurrentlyOnLoan()
    {
        var borrowedBooks = _loanManager.GetBorrowedBooks();
        Console.WriteLine("Libros actualmente prestados:");
        foreach (var book in borrowedBooks)
        {
            Console.WriteLine($"- {book.Title} ({book.Isbn})");
            Console.WriteLine("**********************************************");
        }
    }

    public void ReportByAllBorrowedBooks()
    {
        _reportGenerator.PrintAllBorrowedBooks();
    }

    public void ReportOverDueBooks()
    {
        _reportGenerator.PrintOverdueBooks();
    }

    public void ReportUserLoanHistory()
    {
        int memberNumber = userInputHandler.GetValidIntInput("Membership Number(21321312)");
        _reportGenerator.PrintUserLoanHistory(memberNumber);
    }
}
