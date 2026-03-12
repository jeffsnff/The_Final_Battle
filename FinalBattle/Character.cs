using System.Reflection.Metadata.Ecma335;
using static FinalBattle.TurnAction;

namespace FinalBattle;

public abstract class Character
{
  private readonly string _name;
  public bool Ai { get; }
  private int MaxHp { get; }
  private int _currentHp;
  public TurnAction CurrentAttack { get; set; }
  public abstract IAttack Attack { get; }

  protected Character(string name, int maxHp, bool computerControlled)
  {
    _name = name;
    Ai = computerControlled;
    MaxHp = maxHp;
    _currentHp = MaxHp;
  }

  public void ChooseMove()
  {
    Random randomNumber = new Random();

    if (Ai)
    {
      // Generates a random number based off the number of moves in _Action
      // then selects that action that cooresponds to the number.
      CurrentAttack = (TurnAction)randomNumber.Next(Enum.GetNames<TurnAction>().Length);
      return;
    }
    string[] actions = Enum.GetNames<TurnAction>();
    while (true)
    {
      Console.WriteLine("What would you like to do?");
      for (int i = 0; i < actions.Length; i++)
      {
        Console.WriteLine($"{i} - {actions[i]}");
      }

      if (int.TryParse(Console.ReadLine(), out int index))
      {
        if (!(index > actions.Length))
        {
          CurrentAttack = Enum.GetValues<TurnAction>().ElementAt(index);
          break;
        }
      }
      Console.WriteLine("That is not an option!");
      Console.ReadKey();
    }
  }

  /// <summary>
  /// Displays the characters move, damage and enemies updated health or death
  /// </summary>
  /// <param name="attack"></param>
  /// <param name="defender"></param>
  public void PerformAction(TurnAction attack, Character defender = null)
  {
    string attackName = Attack.Name;
    int attackDamage = Attack.Damage;
    
    if (attack == TurnAction.Attack)
    {
      defender.Health = (defender.Health - attackDamage);
      
      Console.WriteLine($"{Name} used {attackName} on {defender}.");
      Console.WriteLine($"{Attack.Name} dealt {attackDamage} damage to {defender}");
      string playerUpdate = defender.Health == 0 ? $"{defender} has died!" : $"{defender} is now {defender.Health}/{defender.MaxHP}";
      Console.WriteLine(playerUpdate);
    }
  }
  public int Health
  {
    get => _currentHp;
    set => _currentHp = value;
  }
  public int MaxHP => MaxHp;
  public virtual string Name => _name;
}