namespace FinalBattle;

public class TrueProgrammer(string name, bool computerControlled = false) : Character(name, computerControlled)
{
  public override int MaxHp { get; } = 25;
  public override IAttack Attack { get; } = new Punch();
}