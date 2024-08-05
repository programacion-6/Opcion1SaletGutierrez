using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Manager;

namespace Opcion1SaletGutierrez.src.Handler.BookHandler;

public class RemoveBookHandler
{
    private readonly BookManager _bookManager;
    private readonly Printer _printer;
    private readonly UserInputHandler _userInputHandler;
    private readonly IBookValidator _bookValidator;

    public RemoveBookHandler(BookManager bookManager, Printer printer, UserInputHandler userInputHandler, IBookValidator bookValidator)
    {
        _bookManager = bookManager;
        _printer = printer;
        _userInputHandler = userInputHandler;
        _bookValidator = bookValidator;
    }

    public void RemoveABookOption()
    {
        while (true)
        {
            string isbn = CollectISBNInformation();
            var book = _bookManager.SearchBookByIsbn(isbn);

            if (book == null)
            {
                _printer.PrintMessage("Book not found.");
                continue;
            }

            _printer.DisplayBookDetails(book);
            if (ConfirmBookDeletion())
            {
                ProcessBookRemoval(isbn);
                break;
            }
            else
            {
                _printer.PrintMessage("Book deletion has been cancelled");
                break;
            }
        }
    }

    private bool ConfirmBookDeletion()
    {
        _printer.DisplayConfirmationYesOrNo("delete the book");
        return _userInputHandler.ConfirmOption();
    }

    private void ProcessBookRemoval(string isbn)
    {
        if (_bookManager.RemoveBook(isbn))
        {
            _printer.PrintThatTheOrderWasCorrectlyFulfilled("Book", "removed");
        }
        else
        {
            _printer.PrintTheActionWasNotPerformedCorrectly("book", "removed", "because it is not in the library");
        }
    }

    private string CollectISBNInformation()
    {
        return _userInputHandler.CollectISBN(_bookValidator, "Enter the ISBN of the book (i.e.: 978-987-25620-2-1): ");
    }
}
