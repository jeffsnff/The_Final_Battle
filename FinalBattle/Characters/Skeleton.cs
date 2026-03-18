namespace FinalBattle;

public class Skeleton(bool computerControlled = true) : Character(computerControlled)
{
  public override string Name { get; } = "SKELETON";
  public override int MaxHp { get; } = 5;
  public override IAttack Attack { get; } = new BoneCrunch();
}