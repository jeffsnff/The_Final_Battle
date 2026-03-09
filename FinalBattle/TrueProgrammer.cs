namespace FinalBattle;

public class TrueProgrammer(string name, bool computerControlled = false) : Character(name, 25, computerControlled, "PUNCH", 1)
{
  private bool Hero { get; } = true;
  public override string ToString()
  {
    return $"{Name}";
  }
}