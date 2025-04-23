abstract public class User(string id, string name)
{
  public string ID { get; set; } = id;
  public string Name { get; set; } = name;

  virtual public string GetRole()
  {
    return "User";
  }
}
