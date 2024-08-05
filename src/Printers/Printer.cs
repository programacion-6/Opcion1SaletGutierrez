using Opcion1SaletGutierrez.src.Enums;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez;

public class Printer
{
    public void PrintObjectIsEmpty(string printObject)
    {
        Console.WriteLine($"{printObject} is empty, enter a correct {printObject}");
    }

    public void PrintMinimumAndMaximumCharacters(string printObject, int minCharactersLength, int maxCharactersLength)
    {
        Console.WriteLine($"The {printObject} must be between {minCharactersLength} and {maxCharactersLength} characters.");
    }

    public void PrintMessageOfIncorrectData(string printObject)
    {
        Console.WriteLine($"{printObject} is not written correctly, enter a correct {printObject} as in the example provided.");
    }

    public void PrintChosenOptionIsNotValid(string printObject)
    {
        Console.WriteLine($"The chosen option is not in the list of {printObject}, enter a correct option according to the list");
    }

    public void PrintTheMessageOfThePublicationOfAnInvalidYear()
    {
        Console.WriteLine($"The year of publication is not valid. It must be a positive year and not greater than the current year.");
    }

    public void PrintThatTheOrderWasCorrectlyFulfilled(string printObject, string action)
    {
        Console.WriteLine($"The {printObject} was {action} successfully.");
    }

    public void PrintTheActionWasNotPerformedCorrectly(string printObject, string action, string reason)
    {
        Console.WriteLine($"The {printObject} could not be {action} {reason}");
    }

    public void DisplayGenres()
    {
        var genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();
        for (int i = 0; i < genres.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {genres[i]}");
        }
    }

    public void DisplayBookDetails(Book book)
    {
        Console.WriteLine($"Title: {book.Title}");
        Console.WriteLine($"Author: {book.Author}");
        Console.WriteLine($"ISBN: {book.Isbn}");
        Console.WriteLine($"Genre: {book.Genre}");
        Console.WriteLine($"Publication Year: {book.PublicationYear}");
    }

    public void DisplayConfirmationYesOrNo(string action)
    {
        Console.WriteLine($"Are you sure you want to {action}?");
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");
    }

    public void PrintThatYouCanOnlyPrintNumberOneOrTwo()
    {
        Console.WriteLine("You can only choose number 1 or 2");
    }
}
