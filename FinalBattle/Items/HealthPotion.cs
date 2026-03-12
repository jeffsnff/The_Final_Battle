namespace FinalBattle;

public class HealthPotion(int healingPower) : Item("Health Potion")
{
    private int _healingPower = healingPower;

    public int Take()
    {
        return _healingPower;
    }
    
    public override string ToString()
    {
        return $"{Name}";
    }
}