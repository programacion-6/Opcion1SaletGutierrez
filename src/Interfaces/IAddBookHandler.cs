using Opcion1SaletGutierrez.src.Enums;

namespace Opcion1SaletGutierrez;

public interface IAddBookHandler
{
    string CollectTitleInformation();

    string CollectAuthorInformation();

    string CollectISBNInformation();

    Genre CollectGenreInformation();

    int CollectPublicationYearInformation();
}
