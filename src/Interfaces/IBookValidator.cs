using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Interfaces;

public interface IBookValidator
{

    bool IsBookDuplicate(IDataManager<Book> dataManager, Book book);

    public bool ValidateEmptyTitle(string title);

    bool ValidateTitleLength(string title);

    bool ValidateEmptyAuthor(string author);

    bool ValidateAuthorLength(string author);

    bool ValidateEmptyISBN(string book);

    bool ValidateISBNThatIsWrittenCorrectly(string isbn);

    bool ValidateTheGenreWithinTheList(int genre);

    bool ValidatePublicationYearWithinTheRange(int publicationYear);

    bool ValidateGenre(int genre);
}
