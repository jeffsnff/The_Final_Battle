namespace FinalBattle;

public abstract class Gear() : Item()
{
    public abstract string Description { get; }
    public abstract int Attack { get; }
    public abstract GearType Type { get; }
}