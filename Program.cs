using Opcion1SaletGutierrez.src.Enums;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez;

class Program
{
    static void Main()
    {
        // Ruta al archivo JSON
        //string jsonFilePath = "src/Jsons/books.json";

        // Crear una instancia de BookManager
        var inputHandler = new BookInputHandler();

        inputHandler.CollectBookData();

        // Agregar un nuevo libro
        /* var newBook = new Book
        {
            Title = "1984",
            Author = "George Orwell",
            Isbn = "978-045-15-2-49-35",
            Genre = Genre.Romance,
            PublicationYear = 1949,
            IsAvailable = true
        };
        bool added = bookManager.AddBook(newBook);
        Console.WriteLine($"Book added: {added}"); */

        // Obtener un libro por ISBN
        /* var book = bookManager.GetBookByIsbn("978-006-11-2-008-0");
        if (book != null)
        {
            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"Author: {book.Author}");
            Console.WriteLine($"ISBN: {book.Isbn}");
            Console.WriteLine($"Genre: {book.Genre}");
            Console.WriteLine($"Publication Year: {book.PublicationYear}");
            Console.WriteLine($"Available: {book.IsAvailable}");
        }
        else
        {
            Console.WriteLine("Book not found.");
        } */

        // Actualizar un libro
        /* var updatedBook = new Book
        {
            Title = "1984",
            Author = "George Orwell Orwell",
            Isbn = "978-045-15-2-49-36",
            Genre = Genre.Dystopia,
            PublicationYear = 1949,
            IsAvailable = true
        };
        bool updated = bookManager.UpdateBook("978-045-15-2-49-35", updatedBook);
        Console.WriteLine($"Book updated: {updated}"); */

        // Eliminar un libro
        // bool removed = bookManager.RemoveBook("978-006-11-2-008-4");
        // Console.WriteLine($"Book removed: {removed}");
    }
}
