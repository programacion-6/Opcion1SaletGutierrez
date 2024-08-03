using Opcion1SaletGutierrez.src.Models;

namespace Opcion1SaletGutierrez.src.Interfaces;

public interface IBookManager
{
    List<Book> SearchByBookTitle(string title);

    List<Book> SearchByBookAuthor(string author);

    List<Book> SearchBookByGenre(string genre);

    Book SearchBookByIsbn(string isbn);

    void MarkBookAsUnavailable(Book book);

    void MarkBookAsAvailable(Book book);

    List<Book> GetAllBorrowedBooks();

    bool AddBook(Book book);

    bool RemoveBook(string isbn);

    bool UpdateBook(string isbn, Book updatedBook);

}