using static FinalBattle.TurnManager;

namespace FinalBattle;

public class Battle
{
  private readonly Party _heroes;
  private readonly Party _enemies;
  private static Character _attacker;
  private static Character _defender;

  public Battle(Party heroes, Party enemies)
  {
    _heroes = heroes;
    _enemies = enemies;
    AddInventory(_heroes);
    AddInventory(_enemies);
    
  }

  /// <summary>
  /// Execute the Game Battle
  /// </summary>
  public void ExecuteBattle()
  {
    BattleUI.Enemies = _enemies.party;
    BattleUI.Heros = _heroes.party;
    Turn(_heroes.party, _enemies.party, _heroes.Inventory);
    if (_enemies.party.Count <= 0)
    {
      return;
    }
    Turn(_enemies.party, _heroes.party, _enemies.Inventory);
  }
  
  /// <summary>
  /// Adds inventory to the party
  /// </summary>
  /// <param name="party"></param>
  private void AddInventory(Party party)
  {
    if (party.Equals(_heroes))
    {
      party.Inventory.Add(new HealthPotion());
      party.Inventory.Add(new Sword());
      return;
    }
    party.Inventory.Add(new HealthPotion());
  }
}