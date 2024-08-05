using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez;

public interface IUserValidator
{
    bool IsUserDuplicate(IDataManager<User> dataManager, User user);

    bool ValidateEmptyName(string name);

    bool ValidateUsernameSize(string usernameSize);

    bool ValidateEmptyMemberNumber(string memberNumber);

    bool ValidateEmptyContactInfo(string contactInfo);

    bool ValidateContactInfoWithFormat(string contactInfo);

    bool ValidateMemberNumberFormat(string memberNumber);
}
