namespace FinalBattle;

public class TrueProgrammer(string name, bool computerControlled = false) : Character(computerControlled)
{
  public override string Name { get; } = name;
  public override int MaxHp { get; } = 25;
  public override IAttack Attack { get; } = new Punch();
}