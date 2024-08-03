﻿using Opcion1SaletGutierrez.src.Enums;
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
    }
}
