using Opcion1SaletGutierrez.src.Enums;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez;

public class Printer
{
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

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
        Console.WriteLine(new string('*', 55));
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

    public void DisplayRentalInstructions()
    {
        Console.WriteLine("If you want to rent the book, go to the book lending section and remember the ISBN code to add it.");
    }

    public void PrintNoticeOfTheActionYouHaveToTake(string printObject, string example)    
    {
        Console.WriteLine($"Enter the {printObject} of the book you wish to search for: (i.e. {example}).");
    }

    public void DisplayBookNotFound()
    {
        Console.WriteLine("Book not found.");
    }

    public void DisplayUserNotFound()
    {
        Console.WriteLine("User not found.");
    }

    public void DisplayInvalidOption()
    {
        Console.WriteLine("Invalid option. Please select a valid option.");
    }

    public void DisplayInvalidOptionLenght(string min, string max)
    {
        Console.WriteLine($"Invalid option.  Please enter a number between {min} and {max}.");
    }

    public void DisplayUserDetails(User user)
    {
        Console.WriteLine($"Name: {user.Name}");
        Console.WriteLine($"Member Number: {user.MemberNumber}");
        Console.WriteLine($"Contact Info: {user.ContactInfo}");
        Console.WriteLine(new string('*', 55));
    }

    public void DisplayInvalidInputMessage(string printObject)
    {
        Console.WriteLine($"Please enter a valid {printObject}.");
    }
}
