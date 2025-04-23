using LibraryManager.Models;

class Program
{

  static void SeedBook()
  {
    library.AddBook(new Book
    {
      ID = "1",
      Title = "Clean Code",
      Author = "Robert C. Martin",
      YearPublished = 2008
    });

    library.AddBook(new Book
    {
      ID = "2",
      Title = "The Pragmatic Programmer",
      Author = "Andy Hunt, Dave Thomas",
      YearPublished = 1999
    });

    library.AddBook(new Book
    {
      ID = "3",
      Title = "Design Patterns",
      Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
      YearPublished = 1994
    });

    library.AddBook(new Book
    {
      ID = "4",
      Title = "Refactoring",
      Author = "Martin Fowler",
      YearPublished = 1999
    });

    library.AddBook(new Book
    {
      ID = "5",
      Title = "C# in Depth",
      Author = "Jon Skeet",
      YearPublished = 2010
    });
  }

  static readonly LibraryService library = new();
  static void Main()
  {
    SeedBook();
    Console.WriteLine("enter your name");
    string? name = Console.ReadLine();
    Member member = new("1", "Guest");
    if (name != null)
    {
      member.Name = name;
    }
    while (true)
    {
      Console.WriteLine("Choose what you want to do");
      Console.WriteLine("1. List all books");
      Console.WriteLine("2. Search for book by title");
      Console.WriteLine("3. Borrow a book");
      Console.WriteLine("4. Return a book");
      Console.WriteLine("5. Exit");

      string? command = Console.ReadLine();

      switch (command)
      {
        case "1":
          library.List();
          break;
        case "2":
          Console.WriteLine("Which Book do you want to search?");
          string? title = Console.ReadLine();
          if (title != null)
          {
            Book? book = library.FindByTitle(title);
            if (book != null)
            {
              Console.WriteLine($"found book with id {book.ID}, title is {book.Title}");
            }
            else
            {
              Console.WriteLine("no book found");
            }
          }
          ;
          break;
        case "3":
          Console.WriteLine("Which Book do you want to borrow?");
          string? id = Console.ReadLine();
          if (id != null)
          {
            Book? book = library.FindById(id);
            if (book != null)
            {
              ((IBorrowable)member).BorrowBook(book);
              Console.WriteLine($"Borrowed book with id {book.ID}, title is {book.Title}");
            }
            else
            {
              Console.WriteLine("no book found");
            }
          }
          ;
          break;
        case "4":
          Console.WriteLine("Which Book do you want to return?");
          string? returnId = Console.ReadLine();
          if (returnId != null)
          {
            Book? book = library.FindById(returnId);
            if (book != null)
            {
              ((IBorrowable)member).ReturnBook(book);
              Console.WriteLine($"Returned book with id {book.ID}, title is {book.Title}");
            }
            else
            {
              Console.WriteLine("no book found");
            }
          }
          ;
          break;
        case "5":
          Console.WriteLine("bye");
          return;
        default:
          Console.WriteLine("only 1-5");
          break;
      }
    }
  }
}
