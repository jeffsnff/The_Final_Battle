namespace FinalBattle;

public class HealthPotion() : Item()
{
    public int HealingPower { get; } = 5;
    public override string Name { get; }= "Health Potion";
}