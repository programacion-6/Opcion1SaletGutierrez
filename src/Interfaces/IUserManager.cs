using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Interfaces;

public interface IUserManager
{
    List<User> SearchUserByName(string nameUser);

    User SearchUserByMemberNumber(int memberNumber);

    User SearchUserByContactInfo(string contactInfo);

    bool AddUser(User user);

    bool RemoveUser(int memberNumber);

    bool UpdateUser(int memberNumber, User updatedUser);
}
