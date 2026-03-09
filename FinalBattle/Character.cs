using System.Reflection.Metadata.Ecma335;

namespace FinalBattle;

public class Character
{
  private readonly string _name;
  private string _attackAction { get; }
  private int _attackDamage { get; }
  public bool Ai { get; }
  private int MaxHp { get; }
  private int _currentHp;
  public Action CurrentAttack { get; set; }

  protected Character(string name, int maxHp, bool computerControlled, string attackAction, int attackDamage)
  {
    _name = name;
    Ai = computerControlled;
    MaxHp = maxHp;
    _currentHp = MaxHp;
    _attackAction = attackAction;
    _attackDamage = attackDamage;
  }

  public void ChooseMove()
  {
    Random randomNumber = new Random();

    if (Ai)
    {
      // Generates a random number based off the number of moves in _Action
      // then selects that action that cooresponds to the number.
      CurrentAttack = (Action)randomNumber.Next(Enum.GetNames<Action>().Length);
      return;
    }
    string[] actions = Enum.GetNames<Action>();
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
          CurrentAttack = Enum.GetValues<Action>().ElementAt(index);
          break;
        }
      }
      Console.WriteLine("That is not an option!");
      Console.ReadKey();
    }
  }

  /// <summary>
  /// Displays the character name and action
  /// </summary>
  /// <param name="attacker"></param>
  /// <param name="defender"></param>
  public void PerformAction(Action attack, Character defender = null)
  {
    if (attack == Action.Attack)
    {
      defender.Health = (defender.Health - _attackDamage);
      
      Console.WriteLine($"{Name} used {_attackAction} on {defender}.");
      Console.WriteLine($"{_attackAction} dealt {_attackDamage} damage to {defender}");
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

  public enum Action
  {
    Nothing,
    Inventory,
    Attack
  }
}