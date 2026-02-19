using System.Reflection.Metadata.Ecma335;

namespace FinalBattle;

public class Party
{
  private List<Character> party = [];
  private List<Item> inventory = [];

  public Character Add
  {
    set => party.Add(value);
  }

  public List<Character> Members => party;

  public Item Inventory
  {
    set => inventory.Add(value);
  }
  public int Count => party.Count;

  public Character First => party.First();

}