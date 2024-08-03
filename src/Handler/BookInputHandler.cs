using System.Text.RegularExpressions;
using Opcion1SaletGutierrez.src.Enums;
using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Manager;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Handler;

public class BookInputHandler
{
    private string jsonFilePath = "src/Jsons/books.json";
    private IDataManager<Book> dataManager;
    private BookManager _bookManager;

    public BookInputHandler()
    {
        dataManager = new DataManager<Book>(jsonFilePath);
        _bookManager = new BookManager(dataManager);
    }

    public void CollectBookData()
    {
        string title;
        while (true)
        {
            Console.Write("Ingrese el título del libro: ");
            title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("El título está vacío. Ingrese un título correcto.");
            }
            else
            {
                break;
            }
        }

        string author;
        while (true)
        {
            Console.Write("Ingrese el autor del libro: ");
            author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("El autor está vacío. Ingrese un autor correcto.");
            }
            else
            {
                break;
            }
        }

        string isbn;
        while (true)
        {
            Console.Write("Ingrese el ISBN del libro: ");
            isbn = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("El ISBN está vacío. Ingrese un ISBN correcto.");
            }
            else if (!IsValidIsbn(isbn))
            {
                Console.WriteLine("El ISBN no está escrito correctamente. Ingrese un ISBN correcto como el ejemplo proporcionado.");
            }
            else
            {
                break;
            }
        }

        Genre genre;
        while (true)
        {
            Console.WriteLine("Seleccione un género:");
            DisplayGenres();
            string genreInput = Console.ReadLine();
            if (int.TryParse(genreInput, out int genreIndex) && genreIndex >= 1 && genreIndex <= Enum.GetValues(typeof(Genre)).Length)
            {
                genre = (Genre)(genreIndex - 1);
                break;
            }
            else
            {
                Console.WriteLine("El género no está dentro de la lista de géneros. Ingrese un número que corresponda a la lista.");
            }
        }

        int publicationYear;
        while (true)
        {
            Console.Write("Ingrese el año de publicación del libro: ");
            if (!int.TryParse(Console.ReadLine(), out publicationYear))
            {
                Console.WriteLine("El año de publicación no es correcto. Ingrese un número como el ejemplo proporcionado.");
            }
            else
            {
                break;
            }
        }

        var book = new Book
        {
            Title = title,
            Author = author,
            Isbn = isbn,
            Genre = genre,
            PublicationYear = publicationYear
        };

        if (_bookManager.AddBook(book))
        {
            Console.WriteLine("Libro agregado exitosamente.");
        }
        else
        {
            Console.WriteLine("No se pudo agregar el libro porque ya existe en la librería");
        }
    }

    private void DisplayGenres()
    {
        var genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();
        for (int i = 0; i < genres.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {genres[i]}");
        }
    }

    private bool IsValidIsbn(string isbn)
    {
        var isbnPattern = @"^(\d{1,5}-\d{1,7}-\d{1,7}-\d{1,7}-\d{1})$";

        if (Regex.IsMatch(isbn, isbnPattern))
        {
            string digitsOnly = isbn.Replace("-", "");

            return digitsOnly.Length == 13;
        }

        return false;
    }
}