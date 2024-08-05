using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Validators;

public class UserValidator : IUserValidator
{
    private readonly IValidatorManager<User> _validatorManager;

    public UserValidator(IValidatorManager<User> validatorManager)
    {
        _validatorManager = validatorManager;
    }

    public bool IsUserDuplicate(IDataManager<User> dataManager, User user)
    {
        return dataManager.SearchById("MemberNumber", user.MemberNumber) != null
                || dataManager.SearchByAttribute("Name", user.Name).Any()
                || dataManager.SearchByAttribute("ContactInfo", user.ContactInfo).Any();
    }

    public bool ValidateContactInfoWithFormat(string contactInfo)
    {
        return contactInfo.Contains("@") || contactInfo.Contains(".");
    }

    public bool ValidateEmptyContactInfo(string contactInfo)
    {
        return _validatorManager.ValidateNullOrEmpty(contactInfo);
    }

    public bool ValidateEmptyMemberNumber(string memberNumber)
    {
        return _validatorManager.ValidateNullOrEmpty(memberNumber);
    }

    public bool ValidateEmptyName(string name)
    {
        return _validatorManager.ValidateNullOrEmpty(name);
    }

    public bool ValidateUsernameSize(string usernameSize)
    {
        return _validatorManager.ValidateInputLength(usernameSize, 1, 200);
    }

    public bool ValidateMemberNumberFormat(string memberNumber)
    {
        return int.TryParse(memberNumber, out _);
    }
}
