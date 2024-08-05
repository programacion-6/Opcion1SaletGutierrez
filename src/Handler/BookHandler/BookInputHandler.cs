using Opcion1SaletGutierrez.src.Enums;
using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Manager;
using Opcion1SaletGutierrez.src.Models;
using Opcion1SaletGutierrez.src.Validators;

namespace Opcion1SaletGutierrez.src.Handler.BookHandler;

public class BookInputHandler
{
    private string jsonFilePath = "src/Jsons/books.json";
    private IDataManager<Book> dataManager;
    private BookManager _bookManager;
    private IBookValidator _bookValidator;
    private IValidatorManager<Book> _bookValidatorManager;
    private Printer _printer;
    private UserInputHandler _userInputHandler;

    private readonly AddBookHandler _addBookHandler;
    private readonly RemoveBookHandler _removeBookHandler;
    private readonly UpdateBookHandler _updateBookHandler;
    private readonly SearchBookHandler _searchBookHandler;

    public BookInputHandler()
    {
        dataManager = new DataManager<Book>(jsonFilePath);
        _bookValidatorManager = new ValidatorManager<Book>();
        _bookValidator = new BookValidator(_bookValidatorManager);
        _bookManager = new BookManager(dataManager, _bookValidator);
        _printer = new Printer();
        _userInputHandler = new UserInputHandler();

        _addBookHandler = new AddBookHandler(_bookValidator, _bookManager, _printer, _userInputHandler);
        _removeBookHandler = new RemoveBookHandler(_bookManager, _printer, _userInputHandler, _bookValidator);
        _updateBookHandler = new UpdateBookHandler(_bookManager, _printer, _userInputHandler, _bookValidator, _addBookHandler);
        _searchBookHandler = new SearchBookHandler(_bookManager, _printer, _userInputHandler);
    }

    public void ExecuteAddBookOption()
    {
        _addBookHandler.AddABookOption();
    }

    public void ExecuteRemoveBookOption()
    {
        _removeBookHandler.RemoveABookOption();
    }

    public void ExecuteUpdateBookOption()
    {
        _updateBookHandler.UpdateABookOption();
    }

    public void ExecuteSearchBookOption()
    {
        _searchBookHandler.SearchABookOption();
    }

}