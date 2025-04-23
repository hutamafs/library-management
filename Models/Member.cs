using LibraryManager.Models;

public interface IBorrowable
{

  void BorrowBook(Book book);
  void ReturnBook(Book book);
}


public class Member(string id, string name) : User(id, name), IBorrowable
{
  public override string GetRole() => "Member";
  private List<BorrowRecord> _borrowedBooks = [];

  private BorrowRecord? FindRecord(Book book)
  {
    BorrowRecord? foundRecord = _borrowedBooks.Find(r => r.Book == book && r.ReturnDate is null);
    return foundRecord;
  }

  void IBorrowable.BorrowBook(Book book)
  {

    if (FindRecord(book) == null)
    {
      book.IsBorrowed = true;
      _borrowedBooks.Add(new BorrowRecord(
        book,
        this,
        DateTime.UtcNow
      ));
      Console.WriteLine("you successfully borrowed this book");
    }
    else
    {
      Console.WriteLine("you have borrowed this book");
    }
  }

  void IBorrowable.ReturnBook(Book book)
  {
    var record = FindRecord(book);


    if (record == null)
    {
      Console.WriteLine("you never borrow this book");

    }
    else
    {
      var updated = record with { ReturnDate = DateTime.UtcNow };
      book.IsBorrowed = false;
      _borrowedBooks.Remove(record);
      _borrowedBooks.Add(updated);
      Console.WriteLine("you successfully returned this book");
    }
  }
}