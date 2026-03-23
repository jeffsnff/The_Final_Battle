namespace FinalBattle;

public class HealthPotion() : Item()
{
    private readonly int _healingPower = 5;
    public override string Name { get; }= "Health Potion";
    public int Take(Character attacker)
    {
        int maxHP = attacker.MaxHp;
        int currentHP = attacker.Health;
        Console.WriteLine($"{attacker.Name} takes {Name}!");
        if ((currentHP + _healingPower) > attacker.MaxHp)
        {
            return maxHP;
        }
        return (currentHP + _healingPower);
    }
}