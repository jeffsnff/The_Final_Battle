namespace FinalBattle;

public class Sword() : Gear()
{
    public override string Name { get; } = "Sword of Fire";
    public override string Description { get; } = "Sword of fire was created by the original Coder of these lands.";
    public override int Attack { get; } = 3;
    public override GearType Type { get; } = GearType.Sword;
}