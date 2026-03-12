namespace FinalBattle;

public class UnCodedOne() : Character("Uncoded One", true)
{
  public override int MaxHp { get; } = 15;
  public override IAttack Attack { get; } = new UnRaviling();
}