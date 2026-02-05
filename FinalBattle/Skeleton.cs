namespace FinalBattle;

public class Skeleton(bool computerControlled = true) : Character("SKELETON", 5, computerControlled)
{
    public override void PerformAction(Character attacker, Character defender)
    {
        Random randomNumber = new Random();
        string? attackerName = attacker.ToString();
        string action = nameof(Action.Nothing).ToUpper();
        int attackDamage = 0;
        if(attacker.CurrentAttack == Action.Attack)
        {
            action = "BONE CRUNCH";
            attackDamage = randomNumber.Next(2);
            defender.Health = defender.Health - attackDamage;
        }
        Console.WriteLine($"{attackerName} used {action} on {defender}.");
        Console.WriteLine($"{action} dealt {attackDamage} damage to {defender}");
        string playerUpdate = defender.Health == 0 ? $"{defender} has died!" : $"{defender} is now {defender.Health}/{defender.MaxHP}";
        Console.WriteLine(playerUpdate);
    }
    
    public override string ToString()
    {
        return $"{Name}";
    }
}