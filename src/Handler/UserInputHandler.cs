using Opcion1SaletGutierrez.src.Interfaces;

namespace Opcion1SaletGutierrez.src.Handler;

public class UserInputHandler
{
    private Printer _printer = new Printer();

    public string GetInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    public int GetValidIntInput(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            Console.WriteLine("Invalid input."); // Please enter a valid number.
        }
    }

    public bool ConfirmOption()
    {
        int option = GetValidIntInput("");
        return YesOrNoOption(option);
    }

    public bool YesOrNoOption(int option)
    {
        if (option != 1 && option != 2)
        {
            _printer.PrintThatYouCanOnlyPrintNumberOneOrTwo();
        }
        return option == 1;
    }

    public string CollectISBN(IBookValidator _bookValidator, string inputMessage)
    {
        string isbn;
        while (true)
        {
            isbn = GetInput(inputMessage);
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
}
