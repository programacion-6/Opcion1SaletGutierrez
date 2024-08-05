using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Manager;

public class UserManager : IUserManager
{
    private readonly IDataManager<User> _dataManager;

    private readonly IUserValidator _userValidator;

    public UserManager(IDataManager<User> dataManager, IUserValidator userValidator)
    {
        _dataManager = dataManager;
        _userValidator = userValidator;
    }

    public bool AddUser(User user)
    {
        if (_userValidator.IsUserDuplicate(_dataManager, user))
        {
            return false;
        }
        return _dataManager.AddItem(user);
    }

    public bool RemoveUser(int memberNumber)
    {
        return _dataManager.RemoveItem("MemberNumber", memberNumber);
    }

    public User SearchUserByMemberNumber(int memberNumber)
    {
        return _dataManager.SearchById("MemberNumber", memberNumber);
    }

    public List<User> SearchUserByName(string nameUser)
    {
        return _dataManager.SearchByAttribute("Name", nameUser);
    }

    public User SearchUserByContactInfo(string contactInfo)
    {
        return _dataManager.SearchById("ContactInfo", contactInfo);
    }

    public bool UpdateUser(int memberNumber, User updatedUser)
    {
        return _dataManager.UpdateItem("MemberNumber", memberNumber, updatedUser);
    }
}
