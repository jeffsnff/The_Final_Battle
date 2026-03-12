namespace FinalBattle;

public class Skeleton(bool computerControlled = true) : Character("SKELETON", computerControlled)
{
  public override int MaxHp { get; } = 5;
  public override IAttack Attack { get; } = new BoneCrunch();
}