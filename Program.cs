using Opcion1SaletGutierrez.src.Enums;
using Opcion1SaletGutierrez.src.Manager;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez;

class Program
{
    static void Main()
    {
        ////// AÑADIR
        // var inputHandler = new BookInputHandler();

        // inputHandler.CollectBookData();

        ///// BUSCAR POR ISBN
        // string jsonFilePath = "src/Jsons/books.json";
        // var dataManager = new DataManager<Book>(jsonFilePath);

        // var data = new BookManager(dataManager);

        // var book = data.SearchBookByIsbn("978-3-16-148410-0");
        // //var book = bookManager.GetBookByIsbn("978-006-11-2-008-0");
        // if (book != null)
        // {
        //     Console.WriteLine($"Title: {book.Title}");
        //     Console.WriteLine($"Author: {book.Author}");
        //     Console.WriteLine($"ISBN: {book.Isbn}");
        //     Console.WriteLine($"Genre: {book.Genre}");
        //     Console.WriteLine($"Publication Year: {book.PublicationYear}");
        //     Console.WriteLine($"Available: {book.IsAvailable}");
        // }
        // else
        // {
        //     Console.WriteLine("Book not found.");
        // }


        //////// BUSCAR POR AUTOR
        // string jsonFilePath = "src/Jsons/books.json";
        // var dataManager = new DataManager<Book>(jsonFilePath);

        // var data = new BookManager(dataManager);

        // var book = data.SearchByBookAuthor("F. Scott Fitzgerald");
        // //var book = bookManager.GetBookByIsbn("978-006-11-2-008-0");
        // foreach (var bookAuthor in book)
        // {
        //     if (book != null)
        //     {
        //         Console.WriteLine($"Title: {bookAuthor.Title}");
        //         Console.WriteLine($"Author: {bookAuthor.Author}");
        //         Console.WriteLine($"ISBN: {bookAuthor.Isbn}");
        //         Console.WriteLine($"Genre: {bookAuthor.Genre}");
        //         Console.WriteLine($"Publication Year: {bookAuthor.PublicationYear}");
        //         Console.WriteLine($"Available: {bookAuthor.IsAvailable}");
        //         Console.WriteLine($"*******************************************************");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Book not found.");
        //     }
        // }



        ///// BUSCAR POR TITULO
        // string jsonFilePath = "src/Jsons/books.json";
        // var dataManager = new DataManager<Book>(jsonFilePath);

        // var data = new BookManager(dataManager);

        // var book = data.SearchByBookTitle("Principito");
        // //var book = bookManager.GetBookByIsbn("978-006-11-2-008-0");
        // foreach (var bookAuthor in book)
        // {
        //     if (book != null)
        //     {
        //         Console.WriteLine($"Title: {bookAuthor.Title}");
        //         Console.WriteLine($"Author: {bookAuthor.Author}");
        //         Console.WriteLine($"ISBN: {bookAuthor.Isbn}");
        //         Console.WriteLine($"Genre: {bookAuthor.Genre}");
        //         Console.WriteLine($"Publication Year: {bookAuthor.PublicationYear}");
        //         Console.WriteLine($"Available: {bookAuthor.IsAvailable}");
        //         Console.WriteLine($"*******************************************************");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Book not found.");
        //     }
        // }


        ///// ACTUALIZAR LIBRO

        // string jsonFilePath = "src/Jsons/books.json";
        // var dataManager = new DataManager<Book>(jsonFilePath);

        // var data = new BookManager(dataManager);

        // var updatedBook = new Book
        // {
        //     Title = "Principito 4",
        //     Author = "F. Scott Fitzgerald",
        //     Isbn = "978-3-16-148810-0",
        //     Genre = Genre.Dystopia,
        //     PublicationYear = 1949,
        //     IsAvailable = true
        // };

        // var book = data.UpdateBook("978-3-16-148810-0", updatedBook);
        // Console.WriteLine(book);


        ///// BUSCAR POR GENERO

        // string jsonFilePath = "src/Jsons/books.json";
        // var dataManager = new DataManager<Book>(jsonFilePath);

        // var data = new BookManager(dataManager);

        // var book = data.SearchBookByGenre("Science_Fiction");

        // foreach (var bookAuthor in book)
        // {
        //     if (book != null)
        //     {
        //         Console.WriteLine($"Title: {bookAuthor.Title}");
        //         Console.WriteLine($"Author: {bookAuthor.Author}");
        //         Console.WriteLine($"ISBN: {bookAuthor.Isbn}");
        //         Console.WriteLine($"Genre: {bookAuthor.Genre}");
        //         Console.WriteLine($"Publication Year: {bookAuthor.PublicationYear}");
        //         Console.WriteLine($"Available: {bookAuthor.IsAvailable}");
        //         Console.WriteLine($"*******************************************************");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Book not found.");
        //     }
        // }



        ////// ELIMINAR UN LIBRO
        // string jsonFilePath = "src/Jsons/books.json";
        // var dataManager = new DataManager<Book>(jsonFilePath);

        // var data = new BookManager(dataManager);
        // bool removed = data.RemoveBook("978-3-16-178810-0");
        // Console.WriteLine($"Book removed: {removed}");



        ///// OBTENER TODOS LOS LIBROS PRESTADOS

        // string jsonFilePath = "src/Jsons/books.json";
        // var dataManager = new DataManager<Book>(jsonFilePath);

        // var data = new BookManager(dataManager);

        // var book = data.GetAllBorrowedBooks();

        // foreach (var bookAuthor in book)
        // {
        //     if (book != null)
        //     {
        //         Console.WriteLine($"Title: {bookAuthor.Title}");
        //         Console.WriteLine($"Author: {bookAuthor.Author}");
        //         Console.WriteLine($"ISBN: {bookAuthor.Isbn}");
        //         Console.WriteLine($"Genre: {bookAuthor.Genre}");
        //         Console.WriteLine($"Publication Year: {bookAuthor.PublicationYear}");
        //         Console.WriteLine($"Available: {bookAuthor.IsAvailable}");
        //         Console.WriteLine($"*******************************************************");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Book not found.");
        //     }
        // }


        /********************************************************************************************************************************/

        ////// AÑADIR

        // string jsonFilePath = "src/Jsons/users.json";
        // var dataManager = new DataManager<User>(jsonFilePath);

        // var data = new UserManager(dataManager);

        // var user = new User
        // {
        //     MemberNumber = 11111111,
        //     Name = "F. Scott Fitzgerald",
        //     ContactInfo = "salet08@hmail.com"
        // };
        // var userAdd = data.AddUser(user);
        // Console.WriteLine(userAdd);



        //////// BUSCAR A USUARIO POR NOMBRE
        // string jsonFilePath = "src/Jsons/users.json";
        // var dataManager = new DataManager<User>(jsonFilePath);

        // var data = new UserManager(dataManager);

        // var user = data.SearchUserByName("John Doe");
        // //var book = bookManager.GetBookByIsbn("978-006-11-2-008-0");
        // foreach (var userName in user)
        // {
        //     if (user != null)
        //     {
        //         Console.WriteLine($"Member Number: {userName.MemberNumber}");
        //         Console.WriteLine($"Name: {userName.Name}");
        //         Console.WriteLine($"Contact Info: {userName.ContactInfo}");
        //         Console.WriteLine($"*******************************************************");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Book not found.");
        //     }
        // }



        ///// BUSCAR POR Member Number
        // string jsonFilePath = "src/Jsons/users.json";
        // var dataManager = new DataManager<User>(jsonFilePath);

        // var data = new UserManager(dataManager);

        // var user = data.SearchUserByMemberNumber(674311);

        // if (user != null)
        // {
        //     Console.WriteLine($"Member Number: {user.MemberNumber}");
        //     Console.WriteLine($"Name: {user.Name}");
        //     Console.WriteLine($"Contact Info: {user.ContactInfo}");
        //     Console.WriteLine($"*******************************************************");
        // }
        // else
        // {
        //     Console.WriteLine("User not found.");
        // }


        


        ///// BUSCAR POR Concatc Info
        // string jsonFilePath = "src/Jsons/users.json";
        // var dataManager = new DataManager<User>(jsonFilePath);

        // var data = new UserManager(dataManager);

        // var user = data.SearchUserByContactInfo("jane.smith@example.com");

        // if (user != null)
        // {
        //     Console.WriteLine($"Member Number: {user.MemberNumber}");
        //     Console.WriteLine($"Name: {user.Name}");
        //     Console.WriteLine($"Contact Info: {user.ContactInfo}");
        //     Console.WriteLine($"*******************************************************");
        // }
        // else
        // {
        //     Console.WriteLine("User not found.");
        // }





        ///// ACTUALIZAR Usuario

        // string jsonFilePath = "src/Jsons/users.json";
        // var dataManager = new DataManager<User>(jsonFilePath);

        // var data = new UserManager(dataManager);

        // var userUpdate = new User
        // {
        //     MemberNumber = 23111111,
        //     Name = "Scott .T Fitzgerald",
        //     ContactInfo = "scottT08@hmail.com"
        // };

        // var userUp = data.UpdateUser(23111111, userUpdate);
        // Console.WriteLine(userUp);




        ////// ELIMINAR UN Usuario
        // string jsonFilePath = "src/Jsons/users.json";
        // var dataManager = new DataManager<User>(jsonFilePath);

        // var data = new UserManager(dataManager);
        // bool removed = data.RemoveUser(654321);
        // Console.WriteLine($"User removed: {removed}");

        // string jsonFilePathUser = "src/Jsons/users.json";
        // string jsonFilePathBook = "src/Jsons/books.json";
        // string jsonFilePathPresentLoan = "src/Jsons/presentLoans.json";
        // // string jsonFilePathLoadHistory = "src/Jsons/loansHistory.json";

        // var bookDataManager = new DataManager<Book>(jsonFilePathBook);
        // var userDataManager = new DataManager<User>(jsonFilePathUser);
        // var loanDataManager = new DataManager<Loan>(jsonFilePathPresentLoan);
        //var loanHistoryDataManager = new DataManager<Loan>(jsonFilePathLoadHistory);

        
        // Préstamo de un libro
        // Instancia de LoanManager
        // var loanManager = new LoanManager(bookDataManager, userDataManager, loanDataManager);

        // int memberNumber = 23111111;
        // string isbn = "978-3-16-178811-9";
        // int loanPeriodDays = 21;

        // bool loanSuccessful = loanManager.BorrowBook(memberNumber, isbn, loanPeriodDays);
        // Console.WriteLine(loanSuccessful ? "El libro ha sido prestado exitosamente." : "No se pudo realizar el préstamo. Verifique los datos ingresados y la disponibilidad del libro.");

        // Devolución de un libro
        // var loanManager = new LoanManager(bookDataManager, userDataManager, loanDataManager);
        // int memberNumber = 123456;
        // string isbn = "978-0-452-28423-4";
        // bool returnSuccessful = loanManager.ReturnBook(memberNumber, isbn);
        // Console.WriteLine(returnSuccessful ? "El libro ha sido devuelto exitosamente." : "No se pudo realizar la devolución. Verifique los datos ingresados.");

        // // Verificar disponibilidad de un libro
        // var loanManager = new LoanManager(bookDataManager, userDataManager, loanDataManager);
        // string isbn = "978-3-16-178810-0";
        // bool isAvailable = loanManager.IsBookAvailable(isbn);
        // Console.WriteLine(isAvailable ? "El libro está disponible." : "El libro no está disponible.");

        // // Obtener lista de libros prestados
        // var loanManager = new LoanManager(bookDataManager, userDataManager, loanDataManager);
        // var borrowedBooks = loanManager.GetBorrowedBooks();
        // Console.WriteLine("Libros actualmente prestados:");
        // foreach (var book in borrowedBooks)
        // {
        //     Console.WriteLine($"- {book.Title} ({book.Isbn})");
        //     Console.WriteLine("**********************************************");
        // }

    }
}
