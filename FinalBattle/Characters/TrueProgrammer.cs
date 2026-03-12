namespace FinalBattle;

public class TrueProgrammer(string name, bool computerControlled = false) : Character(name, 25, computerControlled)
{
  private bool Hero { get; } = true;
  public override IAttack Attack { get; } = new Punch();
}