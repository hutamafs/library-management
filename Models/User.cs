abstract public class User(string id, string name)
{
  public required string ID { get; set; } = id;
  public required string Name { get; set; } = name;

  virtual public string GetRole()
  {
    return "User";
  }
}
