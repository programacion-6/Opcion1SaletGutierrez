using Opcion1SaletGutierrez.src.Manager;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Handler;

public class AddUserHandler : IAddUserHandler
{
    private IUserValidator _userValidator;
    private UserManager _userManager;
    private Printer _printer;
    private UserInputHandler _userInputHandler;

    public AddUserHandler(IUserValidator userValidator, UserManager userManager, Printer printer, UserInputHandler userInputHandler)
    {
        _userValidator = userValidator;
        _userManager = userManager;
        _printer = printer;
        _userInputHandler = userInputHandler;
    }

    public void AddUserOption()
        {
            string name = CollectNameInformation();
            int memberNumber = CollectMemberNumberInformation();
            string contactInfo = CollectContactInfoInformation();

            var user = new User
            {
                Name = name,
                MemberNumber = memberNumber,
                ContactInfo = contactInfo
            };

            if (_userManager.AddUser(user))
            {
                _printer.PrintThatTheOrderWasCorrectlyFulfilled("User", "added");
            }
            else
            {
                _printer.PrintTheActionWasNotPerformedCorrectly("user", "added", "because it already exists");
            }
        }

        public string CollectNameInformation()
        {
            string name;
            while (true)
            {
                name = _userInputHandler.GetInput("Enter the name of the user: ");
                if (!_userValidator.ValidateEmptyName(name))
                {
                    _printer.PrintObjectIsEmpty("name");
                }
                else if (!_userValidator.ValidateUsernameSize(name))
                {
                    _printer.PrintMinimumAndMaximumCharacters("name", 1, 200);
                }
                else
                {
                    break;
                }
            }
            return name;
        }

        public int CollectMemberNumberInformation()
        {
            string memberNumber;
            while (true)
            {
                memberNumber = _userInputHandler.GetInput("Enter the Member Number: ");
                if (!_userValidator.ValidateEmptyMemberNumber(memberNumber))
                {
                    _printer.PrintObjectIsEmpty("Member Number");
                }
                else if (!_userValidator.ValidateMemberNumberFormat(memberNumber))
                {
                    Console.WriteLine("The Member number format is incorrect. Please enter a valid number.");
                }
                else
                {
                    break;
                }
            }
            return int.Parse(memberNumber);
        }

        public string CollectContactInfoInformation()
        {
            string contactInfo;
            while (true)
            {
                contactInfo = _userInputHandler.GetInput("Enter the contact information: ");
                if (!_userValidator.ValidateEmptyContactInfo(contactInfo))
                {
                    _printer.PrintObjectIsEmpty("contact information");
                }
                else if (!_userValidator.ValidateContactInfoWithFormat(contactInfo))
                {
                    Console.WriteLine("The contact information must contain '@' and '.'. Please enter a valid contact information.");
                }
                else
                {
                    break;
                }
            }
            return contactInfo;
        }

}
