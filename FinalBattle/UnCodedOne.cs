namespace FinalBattle;

public class UnCodedOne() : Character("Uncoded One", 15, true)
{
  public override IAttack Attack { get; } = new UnRaviling();
  public override string ToString()
  {
    return $"{Name}";
  }
}