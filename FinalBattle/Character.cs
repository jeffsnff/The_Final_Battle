namespace FinalBattle;

public class Character
{
    public string name { get; }
    private int maxHP { get; init; }
    public int currentHP { get; set; }
    private bool AI { get; }
    private bool Hero { get; }
    private Random randomNumber = new Random();
    public Character( string characterType = "SKELETON", bool computerControlled = true, bool heroClass = false )
    {
        name = characterType;
        AI = computerControlled;
        Hero = heroClass;
        if (Hero)
        {
            maxHP = 25;
            currentHP = maxHP;
        }
        else
        {
            maxHP = 5;
            currentHP = maxHP;
        }
    }
    public void Move(Character defender)
    {
        Enum action;
        if (AI)
        {
            // Generates a random number based off the number of moves in _Action
            // then selects that action that cooresponds to the number.
            action = (_Action)randomNumber.Next(Enum.GetNames(typeof(_Action)).Length);
        }
        else
        {
            Console.WriteLine("What would you like to do?");
            Console.ReadKey();
            action = _Action.Nothing;
        }

        switch (action)
        {
            case _Action.Nothing:
                Console.WriteLine($"{name} did NOTHING.");
                break;
            case _Action.Attack:
                PerformAction(name, _Action.Attack, defender);
                break;
        }
    }

    public enum _Action
    {
        Nothing,
        Attack
    }
    
    /// <summary>
    /// Displays the character name and action
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    private void PerformAction(string attackerName, _Action attackerAction, Character defender)
    {
        string action = nameof(_Action.Nothing).ToUpper();
        int attackerDamage = 100;
        if(attackerAction == _Action.Attack)
        {
            if (attackerName.Equals("SKELETON"))
            {
                action = "BONE CRUNCH";
                attackerDamage = randomNumber.Next(2);
                defender.currentHP = defender.currentHP - attackerDamage;
            }

            if (Hero)
            {
                action = "PUNCH";
                attackerDamage = 1;
                defender.currentHP = defender.currentHP - attackerDamage;
            }
        }
        Console.WriteLine($"{attackerName} used {action} on {defender.name}.");
        Console.WriteLine($"{action} dealt {attackerDamage} damage to {defender.name}");
        Console.WriteLine($"{defender.name} is now {defender.currentHP}/{defender.maxHP}");
    }
}