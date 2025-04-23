namespace LibraryManager.Models;

public record BorrowRecord(
  Book Book,
  Member BorrowedBy,
  DateTime BorrowDate,
  DateTime? ReturnDate = null
);