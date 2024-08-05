using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Manager;
using Opcion1SaletGutierrez.src.Models;
using Opcion1SaletGutierrez.src.Validators;

namespace Opcion1SaletGutierrez.src.Handler.UserHandler;

public class UserInputHandlerManager
{
    private string jsonFilePath = "src/Jsons/users.json";
    private IDataManager<User> _dataManager;
    private UserManager _userManager;
    private IUserValidator _userValidator;
    private IValidatorManager<User> _userValidatorManager;
    private Printer _printer;
    private UserInputHandler _userInputHandler;

    private readonly AddUserHandler _addUserHandler;
    private readonly RemoveUserHandler _removeUserHandler;
    private readonly UpdateUserHandler _updateUserHandler;
    private readonly SearchUserHandler _searchUserHandler;

    public UserInputHandlerManager()
    {
        _dataManager = new DataManager<User>(jsonFilePath);
        _userValidatorManager = new ValidatorManager<User>();
        _userValidator = new UserValidator(_userValidatorManager);
        _userManager = new UserManager(_dataManager, _userValidator);
        _printer = new Printer();
        _userInputHandler = new UserInputHandler();

        _addUserHandler = new AddUserHandler(_userValidator, _userManager, _printer, _userInputHandler);
        _removeUserHandler = new RemoveUserHandler(_userValidator, _userManager, _printer, _userInputHandler);
        _updateUserHandler = new UpdateUserHandler(_userManager, _printer, _userInputHandler, _userValidator, _addUserHandler);
        _searchUserHandler = new SearchUserHandler(_userManager, _printer, _userInputHandler);
    }

    public void ExecuteAddUserOption()
    {
        _addUserHandler.AddUserOption();
    }

    public void ExecuteRemoveUserOption()
    {
        _removeUserHandler.RemoveAUserOption();
    }

    public void ExecuteUpdateUserOption()
    {
        _updateUserHandler.UpdateAUserOption();
    }

    public void ExecuteSearchUserOption()
    {
        _searchUserHandler.SearchAUserOption();
    }

}
