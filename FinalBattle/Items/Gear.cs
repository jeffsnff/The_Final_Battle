namespace FinalBattle;

public abstract class Gear() : Item()
{
    public abstract string Description { get; }
    public abstract int Attack { get; }
    public abstract GearType Type { get; }
    public void Equip(Gear armor, List<Item> inventory, Character attacker)
    {
        if (attacker.Armor.TryGetValue(armor.Type, out Gear ?currentArmor))
        {
            if (currentArmor.Equals(null))
            {
                return;
            }
            attacker.Armor.Remove(currentArmor.Type);
            inventory.Add(currentArmor);
            attacker.Armor.Add(armor.Type, armor);
            inventory.Remove(armor);
        }
        else
        {
            attacker.Armor.Add(armor.Type, armor);
            inventory.Remove(armor);
        }
        Console.WriteLine($"{attacker.Name} equipped {armor.Name}");
    }
}