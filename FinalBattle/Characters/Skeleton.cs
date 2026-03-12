namespace FinalBattle;

public class Skeleton(bool computerControlled = true) : Character("SKELETON", 5, computerControlled)
{
  public override IAttack Attack { get; } = new BoneCrunch();
}