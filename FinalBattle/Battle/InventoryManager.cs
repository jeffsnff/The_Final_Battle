using static FinalBattle.PlayerInput;

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

    List<string> inventoryItems = new List<string>();
    foreach (Item item in inventory)
    {
      inventoryItems.Add(item.Name);
    }
    
    SelectInventoryItem(UserSelection(attacker, inventoryItems), inventory, attacker);
  }
  
  /// <summary>
  /// Input user selection on Action in Inventory
  /// </summary>
  /// <param name="userSelection"></param>
  /// <param name="inventory"></param>
  /// <param name="attacker"></param>
  private static void SelectInventoryItem(int userSelection, List<Item> inventory, Character attacker)
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