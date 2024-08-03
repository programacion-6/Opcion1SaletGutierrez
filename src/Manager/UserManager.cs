using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Manager;

public class UserManager : IUserManager
{
    private readonly IDataManager<User> _dataManager;

    public UserManager(IDataManager<User> dataManager)
    {
        _dataManager = dataManager;
    }

    public bool AddUser(User user)
    {
        if (IsDuplicate(user))
        {
            return false;
        }
        return _dataManager.AddItem(user);
    }

    private bool IsDuplicate(User user)
    {
        var userByMemberNumber = SearchUserByMemberNumber(user.MemberNumber);
        if (userByMemberNumber != null)
        {
            return true;
        }

        var usersByName = SearchUserByName(user.Name);
        var usersByContactInfo = SearchUserByContactInfo(user.ContactInfo);
        if (usersByName.Any() || usersByContactInfo != null)
        {
            return true;
        }

        return false;
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
