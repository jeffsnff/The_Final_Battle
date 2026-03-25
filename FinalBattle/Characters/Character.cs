namespace FinalBattle;

public abstract class Character
{
  public abstract string Name { get; }
  public bool Ai { get; }
  public abstract int MaxHp { get; protected set; }
  public int CurrentHp { get; protected set; }
  public abstract Dictionary<GearType, Gear> Armor { get; }
  public Action CurrentAttack { get; set; }
  public abstract IAttack Attack { get; }
  protected Character(bool computerControlled)
  {
    Ai = computerControlled;
    CurrentHp = MaxHp;
  }
  /// <summary>
  /// Update the characters health from an attack
  /// </summary>
  /// <param name="damageValue"></param>
  public void TakeDamage(int damageValue)
  {
    CurrentHp = (CurrentHp - damageValue);
    if (CurrentHp < 0)
    {
      CurrentHp = 0;
    }
  }
  /// <summary>
  /// Update the characters health from a heal
  /// </summary>
  /// <param name="potion"></param>
  public void Heal(HealthPotion potion)
  {
    Console.WriteLine($"{Name} takes {potion.Name}!");
    if ((CurrentHp + potion.HealingPower) > MaxHp)
    {
      CurrentHp = MaxHp;
      return;
    }
    CurrentHp += potion.HealingPower;
  }
}