using Opcion1SaletGutierrez.src.Enums;
using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Manager;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Handler.BookHandler;

public class AddBookHandler : IAddBookHandler
{
    public IBookValidator _bookValidator;
    public BookManager _bookManager;
    public Printer _printer;
    public UserInputHandler _userInputHandler;

    public AddBookHandler(IBookValidator bookValidator, BookManager bookManager, Printer printer, UserInputHandler userInputHandler)
    {
        _bookValidator = bookValidator;
        _bookManager = bookManager;
        _printer = printer;
        _userInputHandler = userInputHandler;
    }

    public void AddABookOption()
    {
        string title = CollectTitleInformation();
        string author = CollectAuthorInformation();
        string isbn = CollectISBNInformation();
        Genre genre = CollectGenreInformation();
        int publicationYear = CollectPublicationYearInformation();

        var book = new Book
        {
            Title = title,
            Author = author,
            Isbn = isbn,
            Genre = genre,
            PublicationYear = publicationYear
        };

        if (_bookManager.AddBook(book))
        {
            _printer.PrintThatTheOrderWasCorrectlyFulfilled("Book", "added");
        }
        else
        {
            _printer.PrintTheActionWasNotPerformedCorrectly("book", "added", "because it already exists in the bookstore");
        }
    }

    public string CollectTitleInformation()
    {
        string title;
        while (true)
        {
            title = _userInputHandler.GetInput("Enter the title of the book: ");
            if (!_bookValidator.ValidateEmptyTitle(title))
            {
                _printer.PrintObjectIsEmpty("title");
            }
            else if (!_bookValidator.ValidateTitleLength(title))
            {
                _printer.PrintMinimumAndMaximumCharacters("title", 1, 200);
            }
            else
            {
                break;
            }
        }
        return title;
    }

    public string CollectAuthorInformation()
    {
        string author;
        while (true)
        {
            author = _userInputHandler.GetInput("Enter the author of the book: ");
            if (!_bookValidator.ValidateEmptyAuthor(author))
            {
                _printer.PrintObjectIsEmpty("author");
            }
            else if (!_bookValidator.ValidateAuthorLength(author))
            {
                _printer.PrintMinimumAndMaximumCharacters("author", 1, 200);
            }
            else
            {
                break;
            }
        }
        return author;
    }

    public string CollectISBNInformation()
    {
        return _userInputHandler.CollectISBN(_bookValidator, "Enter the ISBN of the book (i.e.: 978-987-25620-2-1): ");
    }

    public Genre CollectGenreInformation()
    {
        Genre genre;
        while (true)
        {
            _printer.PrintMessage("Select a genre by the index:");
            _printer.DisplayGenres();
            string genreInput = _userInputHandler.GetInput("");
            if (int.TryParse(genreInput, out int genreIndex) && _bookValidator.ValidateTheGenreWithinTheList(genreIndex))
            {
                genre = (Genre)(genreIndex - 1);
                break;
            }
            else
            {
                _printer.PrintChosenOptionIsNotValid("genre");
            }
        }
        return genre;
    }

    public int CollectPublicationYearInformation()
    {
        int publicationYear;
        while (true)
        {
            publicationYear = _userInputHandler.GetValidIntInput("Enter the year of publication of the book (i.e: 1934): ");
            if (!_bookValidator.ValidatePublicationYearWithinTheRange(publicationYear))
            {
                _printer.PrintTheMessageOfThePublicationOfAnInvalidYear();
            }
            else
            {
                break;
            }
        }
        return publicationYear;
    }
}
