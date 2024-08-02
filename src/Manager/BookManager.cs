using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Manager;

public class BookManager : IBookManager
{
    public bool AddBook(Book book)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public List<Book> SearchByBookAuthor(string author)
    {
        throw new NotImplementedException();
    }

    public List<Book> SearchByBookTitle(string title)
    {
        throw new NotImplementedException();
    }

    public bool UpdateBook(string isbn, Book updatedBook)
    {
        throw new NotImplementedException();
    }
}
