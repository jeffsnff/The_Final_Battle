namespace FinalBattle;

public class UnCodedOne() : Character("Uncoded One", 15, true)
{
  public override void PerformAction(Action attack, Character defender)
  {
    string action = nameof(Action.Nothing).ToUpper();
    Random randomAttackDamage = new Random();
    int attackerDamage = randomAttackDamage.Next(4);

    if (CurrentAttack == Action.Attack)
    {
      action = "UNRAVELING";
      defender.Health = (defender.Health - attackerDamage);
    }

    Console.WriteLine($"{Name} used {action} on {defender}.");
    Console.WriteLine($"{action} dealt {attackerDamage} damage to {defender}");
    string playerUpdate = defender.Health == 0 ? $"{defender} has died!" : $"{defender} is now {defender.Health}/{defender.MaxHP}";
    Console.WriteLine(playerUpdate);
  }

  public override string ToString()
  {
    return $"{Name}";
  }
}