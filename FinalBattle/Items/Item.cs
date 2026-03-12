namespace FinalBattle;

public class Item
{
  private string _name;

  public Item(string name)
  {
    _name = name;
  }

  public virtual string Name => _name;
}