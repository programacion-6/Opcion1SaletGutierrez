using Opcion1SaletGutierrez.src.Handler;
using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Handler.BookHandler;

public class SearchBookHandler
{
    private readonly IBookManager _bookManager;
    private readonly Printer _printer;
    private readonly UserInputHandler _userInputHandler;

    public SearchBookHandler(IBookManager bookManager, Printer printer, UserInputHandler userInputHandler)
    {
        _bookManager = bookManager;
        _printer = printer;
        _userInputHandler = userInputHandler;
    }

    public void SearchABookOption()
    {
        bool continueSearching;
        do
        {
            int option = GetValidOptionSearch();
            SearchBookDetails(option);
            _printer.DisplayConfirmationYesOrNo("continue searching");
            continueSearching = _userInputHandler.ConfirmOption();

        } while (continueSearching);

    }

    private int GetValidOptionSearch()
    {
        int option;
        while (true)
        {
            Console.WriteLine("How do you want to search for the book?");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Author");
            Console.WriteLine("3. ISBN");
            Console.WriteLine("4. Genre");

            if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 4)
            {
                return option;
            }

            _printer.DisplayInvalidOptionLenght("1", "4");
        }
    }

    private void SearchBookDetails(int option)
    {
        _printer.DisplayRentalInstructions();
        switch (option)
        {
            case 1:
                SearchByTitle();
                break;
            case 2:
                SearchByAuthor();
                break;
            case 3:
                SearchByISBN();
                break;
            case 4:
                SearchByGenre();
                break;
            default:
                _printer.DisplayInvalidOption();
                break;
        }
    }

    private void SearchByTitle()
    {
        _printer.PrintNoticeOfTheActionYouHaveToTake("title", "The Alchemist");
        string input = Console.ReadLine();
        var results = _bookManager.SearchByBookTitle(input);
        DisplaySearchResults(results);
    }

    private void SearchByAuthor()
    {
        _printer.PrintNoticeOfTheActionYouHaveToTake("author", "Marcelo...");
        string input = Console.ReadLine();
        var results = _bookManager.SearchByBookAuthor(input);
        DisplaySearchResults(results);
    }

    private void SearchByISBN()
    {
        _printer.PrintNoticeOfTheActionYouHaveToTake("ISBN", "978-0-321-68093-3");
        string input = Console.ReadLine();
        var result = _bookManager.SearchBookByIsbn(input);
        DisplaySearchResult(result);
    }

    private void SearchByGenre()
    {
        _printer.PrintNoticeOfTheActionYouHaveToTake("Genre", "Science_Fiction");
        _printer.DisplayGenres();
        string input = Console.ReadLine();
        var results = _bookManager.SearchBookByGenre(input);
        DisplaySearchResults(results);
    }

    private void DisplaySearchResults(IEnumerable<Book> books)
    {
        if (books != null && books.Any())
        {
            foreach (var book in books)
            {
                _printer.DisplayBookDetails(book);
            }
        }
        else
        {
            _printer.DisplayBookNotFound();
        }
    }

    private void DisplaySearchResult(Book book)
    {
        if (book != null)
        {
            _printer.DisplayBookDetails(book);
        }
        else
        {
            _printer.DisplayBookNotFound();
        }
    }
}
