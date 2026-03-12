using System.Reflection.Metadata.Ecma335;
using static FinalBattle.TurnAction;

namespace FinalBattle;

public abstract class Character
{
  private readonly string _name;
  public bool Ai { get; }
  public abstract int MaxHp { get; }
  private int _currentHp;
  public TurnAction CurrentAttack { get; set; }
  public abstract IAttack Attack { get; }
  protected Character(string name, bool computerControlled)
  {
    _name = name;
    Ai = computerControlled;
    _currentHp = MaxHp;
  }
  public int Health
  {
    get => _currentHp;
    set => _currentHp = value;
  }
  public string Name => _name;
}