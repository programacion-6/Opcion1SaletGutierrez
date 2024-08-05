﻿using Opcion1SaletGutierrez.src.Handler.BookHandler;
using Opcion1SaletGutierrez.src.Handler.UserHandler;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Handler.MenuHandler;

public class MenuInputHandler
{
    private Printer _printer = new Printer();
    private BookInputHandler _bookInputHandler = new BookInputHandler();
    private UserInputHandlerManager _userInputHandlerManager = new UserInputHandlerManager();

    public void menu()
    {
        Console.WriteLine("1. Add Book\n"
            + "2. Delete Book\n"
            + "3. Update Book\n"
            + "4. Add User\n"
            + "5. Delete User\n"
            + "6. Update User\n"
            + "7. Book Loans\n"
            + "8. Return Book\n"
            + "9. Search Book\n"
            + "10. Search User\n"
            + "11. Report\n"
            + "12. Cancel");
    }

    public void displayMenu()
    {
        while (true)
        {
            int option = GetValidOptionSearch();
            SearchBookDetails(option);
            if (option == 12)
            {
                break;
            }
        }

    }

    private void SearchBookDetails(int option)
    {
        _printer.DisplayRentalInstructions();
        switch (option)
        {
            case 1:
                _bookInputHandler.ExecuteAddBookOption();
                break;
            case 2:
                _bookInputHandler.ExecuteRemoveBookOption();
                break;
            case 3:
                _bookInputHandler.ExecuteUpdateBookOption();
                break;
            case 4:
                _userInputHandlerManager.ExecuteAddUserOption();
                break;
            case 5:
                _userInputHandlerManager.ExecuteRemoveUserOption();
                break;
            case 6:
                _userInputHandlerManager.ExecuteUpdateUserOption();
                break;
            case 7:

                break;
            case 8:

                break;
            case 9:
                _bookInputHandler.ExecuteSearchBookOption();
                break;
            case 10:
                _userInputHandlerManager.ExecuteSearchUserOption();
                break;
            case 11:

                break;
            case 12:
                Console.WriteLine("come back soon :)");
                break;
            default:
                _printer.DisplayInvalidOption();
                break;
        }
    }

    private int GetValidOptionSearch()
    {
        int option;
        while (true)
        {
            menu();

            if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 12)
            {
                return option;
            }

            _printer.DisplayInvalidOptionLenght("1", "4");
        }
    }
}
