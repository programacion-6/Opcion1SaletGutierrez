using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Handler.UserHandler;

public class SearchUserHandler
{
    private readonly IUserManager _userManager;
    private readonly Printer _printer;
    private readonly UserInputHandler _userInputHandler;

    public SearchUserHandler(IUserManager userManager, Printer printer, UserInputHandler userInputHandler)
    {
        _userManager = userManager;
        _printer = printer;
        _userInputHandler = userInputHandler;
    }

    public void SearchAUserOption()
    {
        bool continueSearching;
        do
        {
            int option = GetValidOptionSearch();
            SearchUserDetails(option);
            _printer.DisplayConfirmationYesOrNo("continue searching");
            continueSearching = _userInputHandler.ConfirmOption();

        } while (continueSearching);
    }

    private int GetValidOptionSearch()
    {
        int option;
        while (true)
        {
            Console.WriteLine("How do you want to search for the user?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Member Number");
            Console.WriteLine("3. Contact Info");

            if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 3)
            {
                return option;
            }

            _printer.DisplayInvalidOptionLenght("1", "3");
        }
    }

    private void SearchUserDetails(int option)
    {
        switch (option)
        {
            case 1:
                SearchByName();
                break;
            case 2:
                SearchByMemberNumber();
                break;
            case 3:
                SearchByContacInfo();
                break;
            default:
                _printer.DisplayInvalidOption();
                break;
        }
    }

    private void SearchByName()
    {
        _printer.PrintNoticeOfTheActionYouHaveToTake("name", "John Doe");
        string input = Console.ReadLine();
        var results = _userManager.SearchUserByName(input);
        DisplaySearchResults(results);
    }

    private void SearchByMemberNumber()
{
    _printer.PrintNoticeOfTheActionYouHaveToTake("Member Number", "12345");
    string input = Console.ReadLine();
    
    if (int.TryParse(input, out int memberNumber))
    {
        var result = _userManager.SearchUserByMemberNumber(memberNumber);
        DisplaySearchResult(result);
    }
    else
    {
        _printer.DisplayInvalidInputMessage("Member Number.");
    }
}


    private void SearchByContacInfo()
    {
        _printer.PrintNoticeOfTheActionYouHaveToTake("Contact Info", "example01@gmail.com");
        string input = Console.ReadLine();
        var result = _userManager.SearchUserByContactInfo(input);
        DisplaySearchResult(result);
    }

    private void DisplaySearchResults(IEnumerable<User> users)
    {
        if (users != null && users.Any())
        {
            foreach (var user in users)
            {
                _printer.DisplayUserDetails(user);
            }
        }
        else
        {
            _printer.DisplayUserNotFound();
        }
    }

    private void DisplaySearchResult(User user)
    {
        if (user != null)
        {
            _printer.DisplayUserDetails(user);
        }
        else
        {
            _printer.DisplayUserNotFound();
        }
    }

}
