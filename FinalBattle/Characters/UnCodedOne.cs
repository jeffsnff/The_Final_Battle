namespace FinalBattle;

public class UnCodedOne() : Character(true)
{
  public override string Name { get; } = "UNCODED ONE";
  public override int MaxHp { get; } = 15;
  public override IAttack Attack { get; } = new UnRaviling();
  public override Dictionary<GearType, Gear> Armor { get; } = new Dictionary<GearType, Gear>();
}