using Opcion1SaletGutierrez.src.Enums;
using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Manager;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Handler.BookHandler;

public class UpdateBookHandler
{
    private readonly BookManager _bookManager;
    private readonly Printer _printer;
    private readonly UserInputHandler _userInputHandler;
    private readonly IBookValidator _bookValidator;
    private readonly IAddBookHandler _addBookHandler;

    public UpdateBookHandler(BookManager bookManager, Printer printer, UserInputHandler userInputHandler, IBookValidator bookValidator, IAddBookHandler addBookHandler)
    {
        _bookManager = bookManager;
        _printer = printer;
        _userInputHandler = userInputHandler;
        _bookValidator = bookValidator;
        _addBookHandler = addBookHandler;
    }

    public void UpdateABookOption()
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

            bool continueEditing;
            do
            {
                int option = GetValidOptionModify();
                UpdateBookDetails(option, book);
                _bookManager.UpdateBook(isbn, book);
                _printer.PrintMessage("Book updated successfully.");

                _printer.DisplayConfirmationYesOrNo("continue editing");
                continueEditing = _userInputHandler.ConfirmOption();

            } while (continueEditing);

            break;
        }
    }

    private void UpdateBookDetails(int option, Book book)
    {
        switch (option)
        {
            case 1:
                book.Title = _addBookHandler.CollectTitleInformation();
                break;
            case 2:
                book.Author = _addBookHandler.CollectAuthorInformation();
                break;
            case 3:
                book.Isbn = _addBookHandler.CollectISBNInformation();
                break;
            case 4:
                book.Genre = _addBookHandler.CollectGenreInformation();
                break;
            case 5:
                book.PublicationYear = _addBookHandler.CollectPublicationYearInformation();
                break;
            default:
                _printer.PrintMessage("Invalid option. Please select a valid option.");
                break;
        }
    }

    private int GetValidOptionModify()
    {
        int option;
        while (true)
        {
            Console.WriteLine("What do you want to modify?");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Author");
            Console.WriteLine("3. ISBN");
            Console.WriteLine("4. Genre");
            Console.WriteLine("5. Year of Publication");

            if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 5)
            {
                return option;
            }

            _printer.PrintMessage("Invalid option. Please enter a number between 1 and 5.");
        }
    }

    private string CollectISBNInformation()
    {
        return _userInputHandler.CollectISBN(_bookValidator, "Enter the ISBN of the book you want to update: ");
    }
}
