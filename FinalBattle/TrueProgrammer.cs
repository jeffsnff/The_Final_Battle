namespace FinalBattle;

public class TrueProgrammer(string name, bool computerControlled = false) : Character(name, 25,computerControlled)
{
    private bool Hero { get; } = true;
    public override void PerformAction(Character attacker, Character defender)
    {
        string action = nameof(Action.Nothing).ToUpper();
        int attackerDamage = 0;
        if(attacker.CurrentAttack == Action.Attack)
        {
            action = "PUNCH";
            attackerDamage = 1;
            defender.Health = (defender.Health - attackerDamage);
        }
        
        Console.WriteLine($"{attacker} used {action} on {defender}.");
        Console.WriteLine($"{action} dealt {attackerDamage} damage to {defender}");
        string playerUpdate = defender.Health == 0 ? $"{defender} has died!" : $"{defender} is now {defender.Health}/{defender.MaxHP}";
        Console.WriteLine(playerUpdate);
    }
    
    public override string ToString()
    {
        return $"{Name}";
    }
}