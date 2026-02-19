using System.Reflection.Metadata.Ecma335;

namespace FinalBattle;

public class Party
{
  private List<Character> party = [];
  private List<Item> _inventory = [new HealthPotion(10)];

  public Character Add
  {
    set => party.Add(value);
  }

  public List<Character> Members => party;

  public Item Inventory
  {
    set => _inventory.Add(value);
    get
    {
      if (_inventory.Count == 0)
      {
        Console.WriteLine("Inventory is empty!");
        return null;
      }
      for (int i = 0; i < _inventory.Count; i++)
      {
        Console.WriteLine($"{i} - {_inventory[i]}");
      }

      while (true)
      {
        Console.Write("Pick item (enter number) : ");
        int.TryParse(Console.ReadLine(), out int index);
        if (index < 0 || index >= _inventory.Count)
        {
          Console.WriteLine("That is not an option!");
          continue;
        }

        return _inventory[index];
      }
    }
  }
  public int Count => party.Count;

  public Character First => party.First();

}