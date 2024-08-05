using Opcion1SaletGutierrez.src.Interfaces;
using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Manager;

public class BookManager : IBookManager
{

    private readonly IDataManager<Book> _dataManager;

    private readonly IBookValidator _bookValidator;

    public BookManager(IDataManager<Book> dataManager, IBookValidator bookValidator)
    {
        _dataManager = dataManager;
        _bookValidator = bookValidator;
    }

    public bool AddBook(Book book)
    {
        if (_bookValidator.IsBookDuplicate(_dataManager, book))
        {
            return false;
        }
        return _dataManager.AddItem(book);
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
        return _dataManager.SearchById("Isbn", isbn);
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
