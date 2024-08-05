using Opcion1SaletGutierrez.src.Enums;
using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Manager;
using Opcion1SaletGutierrez.src.Models;
using Opcion1SaletGutierrez.src.Validators;

namespace Opcion1SaletGutierrez.src.Handler;

public class BookInputHandler
{
    private string jsonFilePath = "src/Jsons/books.json";
    private IDataManager<Book> dataManager;
    private BookManager _bookManager;
    private IBookValidator _bookValidator;
    private IValidatorManager<Book> _bookValidatorManager;
    private Printer _printer;

    public BookInputHandler()
    {
        dataManager = new DataManager<Book>(jsonFilePath);
        _bookValidatorManager = new ValidatorManager<Book>();
        _bookValidator = new BookValidator(_bookValidatorManager);
        _bookManager = new BookManager(dataManager, _bookValidator);
        _printer = new Printer();
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

    private string CollectTitleInformation()
    {
        string title;
        while (true)
        {
            Console.Write("Enter the title of the book: ");
            title = Console.ReadLine();
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

    private string CollectISBNInformation()
    {
        return CollectISBN("Enter the ISBN of the book (i.e.: 978-987-25620-2-1): ");
    }

    private string CollectAuthorInformation()
    {
        string author;
        while (true)
        {
            Console.Write("Enter the author of the book: ");
            author = Console.ReadLine();
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

    private string CollectISBN(string inputMessage)
    {
        string isbn;
        while (true)
        {
            //Console.Write("Enter the ISBN of the book(i.e.: 978-987-25620-2-1): ");
            Console.Write(inputMessage);
            isbn = Console.ReadLine();
            if (!_bookValidator.ValidateEmptyISBN(isbn))
            {
                _printer.PrintObjectIsEmpty("ISBN");
            }
            else if (!_bookValidator.ValidateISBNThatIsWrittenCorrectly(isbn))
            {
                _printer.PrintMessageOfIncorrectData("ISBN");
                Console.WriteLine("The parts of an ISBN are:\n" +
                   "- Book (EAN)\n" +
                   "- Country\n" +
                   "- Publishing House\n" +
                   "- Title Correlation\n" +
                   "- Digit");
            }
            else
            {
                break;
            }
        }
        return isbn;
    }

    private Genre CollectGenreInformation()
    {
        Genre genre;
        while (true)
        {
            Console.WriteLine("Select a genre by the index:");
            _printer.DisplayGenres();
            string genreInput = Console.ReadLine();
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

    private int CollectPublicationYearInformation()
    {
        int publicationYear;
        while (true)
        {
            Console.Write("Enter the year of publication of the book (i.e: 1934): ");
            if (!int.TryParse(Console.ReadLine(), out publicationYear))
            {
                _printer.PrintMessageOfIncorrectData("Publication Year");
            }
            else if (!_bookValidator.ValidatePublicationYearWithinTheRange(publicationYear))
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

    /**********************************************/

    public void RemoveABookOption()
    {
        while (true)
        {
            string isbn = CollectInformationToDeleteABook();
            var book = _bookManager.SearchBookByIsbn(isbn);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                continue;
            }

            _printer.DisplayBookDetails(book);
            _printer.DisplayConfirmationYesOrNo("delete the Book");

            if (ConfirmOption())
            {
                if (_bookManager.RemoveBook(isbn))
                {
                    _printer.PrintThatTheOrderWasCorrectlyFulfilled("Book", "removed");
                    break;
                }
                else
                {
                    _printer.PrintTheActionWasNotPerformedCorrectly("book", "removed", "because it is not in the library");
                }
            }
            else
            {
                Console.WriteLine("Book deletion has been cancelled");
                break;
            }
        }
    }

    private bool ConfirmOption()
    {
        if (int.TryParse(Console.ReadLine(), out int option))
        {
            return YesOrNoOption(option);
        }

        Console.WriteLine("Invalid input.");
        return false;
    }

    public bool YesOrNoOption(int option)
    {
        if (option != 1 && option != 2)
        {
            _printer.PrintThatYouCanOnlyPrintNumberOneOrTwo();
        }
        return option == 1;
    }

    public string CollectInformationToDeleteABook()
    {
        return CollectISBN("Enter the ISBN of the book you want to delete (i.e.: 978-987-25620-2-1): ");
    }

    /**********************************************/

    public void UpdateABookOption()
    {
        while (true)
        {
            string isbn = CollectInformationToUpdateABook();
            var book = _bookManager.SearchBookByIsbn(isbn);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                continue;
            }

            _printer.DisplayBookDetails(book);

            bool continueEditing;
            do
            {
                int option = GetValidOptionModify();
                UpdateBookDetails(option, book);
                _bookManager.UpdateBook(isbn, book);
                Console.WriteLine("Book updated successfully.");

                _printer.DisplayConfirmationYesOrNo("continue editing");
                continueEditing = ConfirmOption();

            } while (continueEditing);

            break;
        }
    }

    private void UpdateBookDetails(int option, Book book)
    {
        switch (option)
        {
            case 1:
                book.Title = CollectTitleInformation();
                break;
            case 2:
                book.Author = CollectAuthorInformation();
                break;
            case 3:
                book.Isbn = CollectISBNInformation();
                break;
            case 4:
                book.Genre = CollectGenreInformation();
                break;
            case 5:
                book.PublicationYear = CollectPublicationYearInformation();
                break;
            default:
                Console.WriteLine("Invalid option. Please select a valid option.");
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

            Console.WriteLine("Invalid option. Please enter a number between 1 and 5.");
        }
    }

    public string CollectInformationToUpdateABook()
    {
        return CollectISBN("Enter the ISBN of the book you want to update (i.e.: 978-987-25620-2-1): ");
    }

    public void SearchABookOption()
    {
        bool continueSearching;
        do
        {

            int option = GetValidOptionSearch();
            SearchBookDetails(option);
            _printer.DisplayConfirmationYesOrNo("continue searching");
            continueSearching = ConfirmOption();

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

            Console.WriteLine("Invalid option. Please enter a number between 1 and 5.");
        }
    }

    private void SearchBookDetails(int option)
    {
        switch (option)
        {
            case 1:
                Console.WriteLine("If you want to rent the book, go to the book lending section and remember the ISBN code to add it.");
                Console.WriteLine("Enter the title of the book you wish to search for: (i.e. The Alchemist).");
                string inputBookSearchByTitle = Console.ReadLine();
                var bookSearchTitle = _bookManager.SearchByBookTitle(inputBookSearchByTitle);
                if (bookSearchTitle != null && bookSearchTitle.Any())
                {
                    foreach (var bookAuthor in bookSearchTitle)
                    {
                        Console.WriteLine($"Title: {bookAuthor.Title}");
                        Console.WriteLine($"Author: {bookAuthor.Author}");
                        Console.WriteLine($"ISBN: {bookAuthor.Isbn}");
                        Console.WriteLine($"Genre: {bookAuthor.Genre}");
                        Console.WriteLine($"Publication Year: {bookAuthor.PublicationYear}");
                        Console.WriteLine($"Available: {bookAuthor.IsAvailable}");
                        Console.WriteLine($"*******************************************************");
                    }
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }

                break;
            case 2:
                Console.WriteLine("If you want to rent the book, go to the book lending section and remember the ISBN code to add it.");
                Console.WriteLine("Enter the author of the book you wish to search for: (i.e. Marcelo...).");
                string inputBookSearchByAuthor = Console.ReadLine();
                var bookSearchAuthor = _bookManager.SearchByBookAuthor(inputBookSearchByAuthor);
                if (bookSearchAuthor != null && bookSearchAuthor.Any())
                {
                    foreach (var bookAuthor in bookSearchAuthor)
                    {

                        Console.WriteLine($"Title: {bookAuthor.Title}");
                        Console.WriteLine($"Author: {bookAuthor.Author}");
                        Console.WriteLine($"ISBN: {bookAuthor.Isbn}");
                        Console.WriteLine($"Genre: {bookAuthor.Genre}");
                        Console.WriteLine($"Publication Year: {bookAuthor.PublicationYear}");
                        Console.WriteLine($"Available: {bookAuthor.IsAvailable}");
                        Console.WriteLine($"*******************************************************");
                    }
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
                break;
            case 3:
                Console.WriteLine("If you want to rent the book, go to the book lending section and remember the ISBN code to add it.");
                Console.WriteLine("Enter the ISBD of the book you wish to search for: (i.e. 978-0-321-68093-3).");
                string inputBookSearchByISBN = Console.ReadLine();
                var bookSearchISBN = _bookManager.SearchBookByIsbn(inputBookSearchByISBN);

                if (bookSearchISBN != null)
                {
                    Console.WriteLine($"Title: {bookSearchISBN.Title}");
                    Console.WriteLine($"Author: {bookSearchISBN.Author}");
                    Console.WriteLine($"ISBN: {bookSearchISBN.Isbn}");
                    Console.WriteLine($"Genre: {bookSearchISBN.Genre}");
                    Console.WriteLine($"Publication Year: {bookSearchISBN.PublicationYear}");
                    Console.WriteLine($"Available: {bookSearchISBN.IsAvailable}");
                    Console.WriteLine($"*******************************************************");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }

                break;
            case 4:
                Console.WriteLine("If you want to rent the book, go to the book lending section and remember the ISBN code to add it.");
                Console.WriteLine("Enter the Genre of the book you wish to search for: (i.e. Science_Fiction).");
                _printer.DisplayGenres();
                string inputBookSearchByGenre = Console.ReadLine();
                var bookSearchGenre = _bookManager.SearchBookByGenre(inputBookSearchByGenre);
                if (bookSearchGenre != null && bookSearchGenre.Any())
                {
                    foreach (var bookAuthor in bookSearchGenre)
                    {

                        Console.WriteLine($"Title: {bookAuthor.Title}");
                        Console.WriteLine($"Author: {bookAuthor.Author}");
                        Console.WriteLine($"ISBN: {bookAuthor.Isbn}");
                        Console.WriteLine($"Genre: {bookAuthor.Genre}");
                        Console.WriteLine($"Publication Year: {bookAuthor.PublicationYear}");
                        Console.WriteLine($"Available: {bookAuthor.IsAvailable}");
                        Console.WriteLine($"*******************************************************");

                    }
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
                break;
            default:
                Console.WriteLine("Invalid option. Please select a valid option.");
                break;
        }
    }

}