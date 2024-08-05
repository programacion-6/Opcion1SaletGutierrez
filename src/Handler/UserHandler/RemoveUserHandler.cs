using Opcion1SaletGutierrez.src.Manager;

namespace Opcion1SaletGutierrez.src.Handler.UserHandler;

public class RemoveUserHandler
{
    private IUserValidator _userValidator;
    private UserManager _userManager;
    private Printer _printer;
    private UserInputHandler _userInputHandler;

    public RemoveUserHandler(IUserValidator userValidator, UserManager userManager, Printer printer, UserInputHandler userInputHandler)
    {
        _userValidator = userValidator;
        _userManager = userManager;
        _printer = printer;
        _userInputHandler = userInputHandler;
    }

    public void RemoveAUserOption()
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
                if (ConfirmUserDeletion())
                {
                    ProcessUserRemoval(memberNumber);
                    break;
                }
                else
                {
                    _printer.PrintMessage("User deletion has been cancelled.");
                    break;
                }
            }
        }

        private bool ConfirmUserDeletion()
        {
            _printer.DisplayConfirmationYesOrNo("delete the user");
            return _userInputHandler.ConfirmOption();
        }

        private void ProcessUserRemoval(int memberNumber)
        {
            if (_userManager.RemoveUser(memberNumber))
            {
                _printer.PrintThatTheOrderWasCorrectlyFulfilled("User", "removed");
            }
            else
            {
                _printer.PrintTheActionWasNotPerformedCorrectly("user", "removed", "because it is not in the system");
            }
        }

        private int CollectMemberNumberInformation()
        {
            string memberNumberInput;
            while (true)
            {
                memberNumberInput = _userInputHandler.GetInput("Enter the Member Number: ");
                if (!_userValidator.ValidateEmptyMemberNumber(memberNumberInput))
                {
                    _printer.PrintObjectIsEmpty("membership number");
                }
                else if (!_userValidator.ValidateMemberNumberFormat(memberNumberInput))
                {
                    Console.WriteLine("The membership number format is incorrect. Please enter a valid number.");
                }
                else
                {
                    break;
                }
            }
            return int.Parse(memberNumberInput);
        }
}
