using LibraryManager.Models;
public class LibraryService
{
  private readonly List<Book> _books = [];

  public void AddBook(Book book)
  {
    _books.Add(book);
  }

  public void List()
  {
    foreach (var b in _books)
    {
      Console.WriteLine($"book id {b.ID}, title: {b.Title}, author: {b.Author}, year: {b.YearPublished}, is borrowed: {b.IsBorrowed}");
    }
  }

  public Book? FindById(string id)
  {
    Book? book = _books.Find(b => b.ID == id);
    return book;
  }

  public Book? FindByTitle(string title)
  {
    Book? book = _books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    return book;
  }

  public List<Book> GetAvailBooks()
  {
    List<Book> availBooks = _books.FindAll(b => !b.IsBorrowed);
    return availBooks;
  }
}