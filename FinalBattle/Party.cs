using System.Reflection.Metadata.Ecma335;

namespace FinalBattle;

public class Party
{
  public List<Character> party = [];
  public List<Item> Inventory = [new HealthPotion(10)];
}