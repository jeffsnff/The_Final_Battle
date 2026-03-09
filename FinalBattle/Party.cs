using System.Reflection.Metadata.Ecma335;

namespace FinalBattle;

public class Party
{
  private List<Character> party = [];
  public List<Item> _inventory = [new HealthPotion(10)];

  public Character Add
  {
    set => party.Add(value);
  }
  public List<Character> Members => party;
  public int Count => party.Count;

  public Character First => party.First();

}