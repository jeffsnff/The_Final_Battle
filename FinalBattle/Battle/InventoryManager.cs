namespace FinalBattle;

public static class InventoryManager
{
  /// <summary>
  /// Checks Party Inventory
  /// </summary>
  /// <param name="inventory"></param>
  /// <param name="attacker"></param>
  public static void CheckInventory(List<Item> inventory, Character attacker)
  {
    if (inventory.Count==0)
    {
      Console.WriteLine("Backpack is empty!");
      return;
    }
    
    if (attacker.Ai)
    {
      Random random = new Random();
      int selection = random.Next(inventory.Count());
      UserSection(selection, inventory, attacker);
      return;
    }
  
    if (!attacker.Ai)
    {
      for (int i = 0; i < inventory.Count; i++)
      {
        Console.WriteLine($"{i + 1} - {inventory[i]}");
      }
      Console.WriteLine("What would you like to take? (enter number)");
      if (int.TryParse(Console.ReadLine(), out int userSelection))
      {
        userSelection -= 1;
        UserSection(userSelection, inventory, attacker);
      }
    }
  }
  
  /// <summary>
  /// Input user selection on Action in Inventory
  /// </summary>
  /// <param name="userSelection"></param>
  /// <param name="inventory"></param>
  /// <param name="attacker"></param>
  private static void UserSection(int userSelection, List<Item> inventory, Character attacker)
  {
    switch (inventory[userSelection])
    {
      case HealthPotion:
        HealthPotion potion = (HealthPotion)inventory[userSelection];
        attacker.Heal(potion);
        inventory.Remove(inventory[userSelection]);
        break;
      case Gear:
        Gear gear = (Gear)inventory[userSelection];
        gear.Equip(gear, inventory, attacker);
        break;
    }
  }
}