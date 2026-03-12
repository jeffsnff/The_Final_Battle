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
  public int Health
  {
    get => _currentHp;
    set => _currentHp = value;
  }
  public int MaxHP => MaxHp;
  public virtual string Name => _name;
}