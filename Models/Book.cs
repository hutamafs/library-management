namespace LibraryManager.Models;

public record Book
{
  public required string ID { get; init; }
  public required string Title { get; init; }
  public required string Author { get; init; }
  public required int YearPublished { get; init; }
  public bool IsBorrowed { get; set; } = false;
};
