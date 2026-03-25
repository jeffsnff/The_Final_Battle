namespace FinalBattle;

public class TrueProgrammer(string name, bool computerControlled = false) : Character(computerControlled)
{
  public override string Name { get; } = name;
  public override int MaxHp { get; protected set; } = 25;
  public override IAttack Attack { get; } = new Punch();
  public override Dictionary<GearType, Gear> Armor { get; } = new Dictionary<GearType, Gear>();
}