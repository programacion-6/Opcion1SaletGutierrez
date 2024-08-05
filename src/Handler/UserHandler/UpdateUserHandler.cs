using Opcion1SaletGutierrez.src.Manager;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Handler.UserHandler;

public class UpdateUserHandler
{
    private readonly UserManager _userManager;
    private readonly Printer _printer;
    private readonly UserInputHandler _userInputHandler;
    private readonly IUserValidator _userValidator;
    private readonly IAddUserHandler _addUserHandler;

    public UpdateUserHandler(UserManager userManager, Printer printer, UserInputHandler userInputHandler, IUserValidator userValidator, IAddUserHandler addUserHandler)
    {
        _userManager = userManager;
        _printer = printer;
        _userInputHandler = userInputHandler;
        _userValidator = userValidator;
        _addUserHandler = addUserHandler;
    }

    public void UpdateAUserOption()
    {
        while (true)
        {
            int memberNumber = CollectMemberNumberInformation();
            var user = _userManager.SearchUserByMemberNumber(memberNumber);

            if (user == null)
            {
                _printer.PrintMessage("User not found.");
                continue;
            }

            _printer.DisplayUserDetails(user);

            bool continueEditing;
            do
            {
                int option = GetValidOptionModify();
                UpdateUserDetails(option, user);
                _userManager.UpdateUser(memberNumber, user);
                _printer.PrintMessage("User updated successfully.");

                _printer.DisplayConfirmationYesOrNo("continue editing");
                continueEditing = _userInputHandler.ConfirmOption();

            } while (continueEditing);

            break;
        }
    }

    private void UpdateUserDetails(int option, User user)
    {
        switch (option)
        {
            case 1:
                user.Name = _addUserHandler.CollectNameInformation();
                break;
            case 2:
                user.MemberNumber = _addUserHandler.CollectMemberNumberInformation();
                break;
            case 3:
                user.ContactInfo = _addUserHandler.CollectContactInfoInformation();
                break;
            default:
                _printer.PrintMessage("Invalid option. Please select a valid option.");
                break;
        }
    }

    private int GetValidOptionModify()
    {
        int option;
        while (true)
        {
            Console.WriteLine("What do you want to modify?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Membership Number");
            Console.WriteLine("3. Contact Details");

            if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 3)
            {
                return option;
            }

            _printer.PrintMessage("Invalid option. Please enter a number between 1 and 3.");
        }
    }

    private int CollectMemberNumberInformation()
    {
        string memberNumberInput;
        while (true)
        {
            memberNumberInput = _userInputHandler.GetInput("Enter the Member Number of the user you want to update: ");
            if (!_userValidator.ValidateEmptyMemberNumber(memberNumberInput))
            {
                _printer.PrintObjectIsEmpty("Member Number");
            }
            else if (!_userValidator.ValidateMemberNumberFormat(memberNumberInput))
            {
                Console.WriteLine("The Mmember Number format is incorrect. Please enter a valid number.");
            }
            else
            {
                break;
            }
        }
        return int.Parse(memberNumberInput);
    }

}
