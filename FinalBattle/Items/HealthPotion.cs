namespace FinalBattle;

public class HealthPotion() : Item()
{
    private int _healingPower = 5;
    public override string Name { get; }= "Health Potion";
    public int Take()
    {
        return _healingPower;
    }
}