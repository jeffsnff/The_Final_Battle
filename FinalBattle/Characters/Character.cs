namespace FinalBattle;

public abstract class Character
{
  public abstract string Name { get; }
  public bool Ai { get; }
  public abstract int MaxHp { get; }
  private int _currentHp;
  public abstract Dictionary<GearType, Gear> Armor { get; }
  public TurnAction CurrentAttack { get; set; }
  public abstract IAttack Attack { get; }
  protected Character(bool computerControlled)
  {
    Ai = computerControlled;
    _currentHp = MaxHp;
  }
  public int Health
  {
    get => _currentHp;
    set => _currentHp = value;
  }
  // public string Name => _name;
}