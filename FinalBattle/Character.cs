namespace FinalBattle;

public class Character
{
    private readonly string _name;
    private int MaxHp { get; }
    private int _currentHp;
    private bool Ai { get; }
    private bool Hero { get; }
    private readonly Random _randomNumber = new Random();
    public Character( string characterType = "SKELETON", bool computerControlled = true, bool heroClass = false )
    {
        _name = characterType;
        Ai = computerControlled;
        Hero = heroClass;
        MaxHp = (Hero) ? 8 : 5; // If character is hero, MaxHp = 8 else, MaxHp = 5;
        _currentHp = MaxHp;
    }
    public void Move(Character defender)
    {
        Enum action;
        if (Ai)
        {
            // Generates a random number based off the number of moves in _Action
            // then selects that action that cooresponds to the number.
            action = (Action)_randomNumber.Next(Enum.GetNames<Action>().Length);
        }
        else
        {
            Console.WriteLine("What would you like to do?");
            // Console.ReadKey();
            action = Action.Nothing;
        }

        switch (action)
        {
            case Action.Nothing:
                Console.WriteLine($"{_name} did NOTHING.");
                break;
            case Action.Attack:
                PerformAction(_name, Action.Attack, defender);
                break;
        }
    }
    
    /// <summary>
    /// Displays the character name and action
    /// </summary>
    /// <param name="attackerName"></param>
    /// <param name="attackerAction"></param>
    /// <param name="defender"></param>
    private void PerformAction(string attackerName, Action attackerAction, Character defender)
    {
        string action = nameof(Action.Nothing).ToUpper();
        int attackerDamage = 0;
        if(attackerAction == Action.Attack)
        {
            if (attackerName.Equals("SKELETON"))
            {
                action = "BONE CRUNCH";
                attackerDamage = _randomNumber.Next(2);
                defender._currentHp = defender._currentHp - attackerDamage;
            }

            if (Hero)
            {
                action = "PUNCH";
                attackerDamage = 1;
                defender._currentHp = defender._currentHp - attackerDamage;
            }
        }
        Console.WriteLine($"{attackerName} used {action} on {defender._name}.");
        Console.WriteLine($"{action} dealt {attackerDamage} damage to {defender._name}");
        Console.WriteLine($"{defender._name} is now {defender._currentHp}/{defender.MaxHp}");
    }

    public int Health => _currentHp;
    public string Name => _name;
    
    private enum Action
    {
        Nothing,
        Attack
    }
}