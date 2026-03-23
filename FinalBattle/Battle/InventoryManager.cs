namespace FinalBattle;

public static class InventoryManager
{
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
  
  private static void UserSection(int userSelection, List<Item> inventory, Character attacker)
  {
    switch (inventory[userSelection])
    {
      case HealthPotion:
        HealthPotion potion = (HealthPotion)inventory[userSelection];
        attacker.Health = potion.Take(attacker);
        inventory.Remove(inventory[userSelection]);
        break;
      case Gear:
        Gear gear = (Gear)inventory[userSelection];
        gear.Equip(gear, inventory, attacker);
        break;
    }
  }
}