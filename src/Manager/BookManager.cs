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

        var booksByAuthor = SearchByBookAuthor(book.Author);
        var booksByTitle = SearchByBookTitle(book.Title);
        if (booksByAuthor.Any() || booksByTitle.Any())
        {
            return true;
        }

        return false;
    }

    public List<Book> GetAllBorrowedBooks()
    {
        throw new NotImplementedException();
    }

    public void MarkBookAsAvailable(Book book)
    {
        throw new NotImplementedException();
    }

    public void MarkBookAsUnavailable(Book book)
    {
        throw new NotImplementedException();
    }

    public bool RemoveBook(string isbn)
    {
        throw new NotImplementedException();
    }

    public List<Book> SearchBookByGenre(string genre)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}
