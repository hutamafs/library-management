class Librarian(string id, string name) : User(id, name)
{
  public override string GetRole() => "Librarian";
}