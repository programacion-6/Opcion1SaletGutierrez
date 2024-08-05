using Opcion1SaletGutierrez.src.Handler.MenuHandler;

namespace Opcion1SaletGutierrez;

class Program
{
    static void Main()
    {
        var menu = new MenuInputHandler();
        Console.WriteLine("Welcome to the Bookstore");
        menu.displayMenu();
    }
}
