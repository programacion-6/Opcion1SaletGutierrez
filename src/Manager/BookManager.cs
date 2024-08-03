using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Manager;

public class BookManager : IBookManager
{

    private readonly IDataManager<Book> _dataManager;

    public BookManager(IDataManager<Book> dataManager)
    {
        _dataManager = dataManager;
    }

    public bool AddBook(Book book)
    {
        if (IsDuplicate(book))
        {
            return false;
        }
        return _dataManager.AddItem(book);
    }

    private bool IsDuplicate(Book book)
    {
        var bookByIsbn = SearchBookByIsbn(book.Isbn);
        if (bookByIsbn != null)
        {
            return true;
        }

        var booksByTitle = SearchByBookTitle(book.Title);
        if (booksByTitle.Any())
        {
            return true;
        }

        return false;
    }

    public List<Book> GetAllBorrowedBooks()
    {
        return _dataManager.LoadData().Where(b => !b.IsAvailable).ToList();
    }

    public void MarkBookAsAvailable(Book book)
    {
        book.IsAvailable = true;
        _dataManager.UpdateItem("Isbn", book.Isbn, book);
    }

    public void MarkBookAsUnavailable(Book book)
    {
        book.IsAvailable = false;
        _dataManager.UpdateItem("Isbn", book.Isbn, book);
    }

    public bool RemoveBook(string isbn)
    {
        return _dataManager.RemoveItem("Isbn", isbn);
    }

    public List<Book> SearchBookByGenre(string genre)
    {
        return _dataManager.SearchByAttribute("Genre", genre);
    }

    public Book SearchBookByIsbn(string isbn)
    {
        return _dataManager.SearchByAttribute("Isbn", isbn).FirstOrDefault();
    }

    public List<Book> SearchByBookAuthor(string author)
    {
        return _dataManager.SearchByAttribute("Author", author);
    }

    public List<Book> SearchByBookTitle(string title)
    {
        return _dataManager.SearchByAttribute("Title", title);
    }

    public bool UpdateBook(string isbn, Book updatedBook)
    {
        return _dataManager.UpdateItem("Isbn", isbn, updatedBook);
    }
}
