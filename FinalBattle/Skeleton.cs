namespace FinalBattle;

public class Skeleton(bool computerControlled = true) : Character("SKELETON", 5, computerControlled, "BONE CRUNCH", 1)
{
  public override string ToString()
  {
    return $"{Name}";
  }
}