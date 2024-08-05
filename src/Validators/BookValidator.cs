using System.Text.RegularExpressions;
using Opcion1SaletGutierrez.src.Enums;
using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Validators;

public class BookValidator : IBookValidator
{
    private readonly IValidatorManager<Book> _validatorManager;

    public BookValidator(IValidatorManager<Book> validatorManager)
    {
        _validatorManager = validatorManager;
    }

    public bool IsBookDuplicate(IDataManager<Book> dataManager, Book book)
    {
        return dataManager.SearchById("Isbn", book.Isbn) != null || dataManager.SearchByAttribute("Title", book.Title).Any();
    }

    public bool ValidateEmptyTitle(string title)
    {
        return _validatorManager.ValidateNullOrEmpty(title);
    }

    public bool ValidateTitleLength(string title)
    {
        return _validatorManager.ValidateInputLength(title, 1, 200);
    }

    public bool ValidateEmptyAuthor(string author)
    {
        return _validatorManager.ValidateNullOrEmpty(author);
    }

    public bool ValidateAuthorLength(string author)
    {
        return _validatorManager.ValidateInputLength(author, 1, 200);
    }

    public bool ValidateEmptyISBN(string isbn)
    {
        return _validatorManager.ValidateNullOrEmpty(isbn);
    }

    public bool ValidateISBNThatIsWrittenCorrectly(string isbn)
    {
        var isbnPattern = @"^(\d{1,5}-\d{1,7}-\d{1,7}-\d{1,7}-\d{1})$";
        return Regex.IsMatch(isbn, isbnPattern);
    }

    public bool ValidateTheGenreWithinTheList(int genreIndex)
    {
        return genreIndex >= 1 && genreIndex <= Enum.GetValues(typeof(Genre)).Length;
    }

    public bool ValidatePublicationYearWithinTheRange(int publicationYear)
    {
        int currentYear = DateTime.Now.Year;
        return publicationYear > 0 && publicationYear <= currentYear;
    }

    public bool ValidateGenre(int genre)
    {
        return Enum.IsDefined(typeof(Genre), genre);
    }
}
