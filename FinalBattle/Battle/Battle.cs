using static FinalBattle.TurnManager;

namespace FinalBattle;

public class Battle
{
  private Party _heros;
  private Party _enemies;
  private static Character _attacker;
  private static Character _defender;

  public Battle(Party heros, Party enemies)
  {
    _heros = heros;
    _enemies = enemies;
    AddInventory(_heros);
    AddInventory(_enemies);
    
  }

  /// <summary>
  /// Execute the Game battle from beginning of program
  /// </summary>
  public void ExecuteBattle()
  {
    BattleUI.Enemies = _enemies.party;
    BattleUI.Heros = _heros.party;
    Turn(_heros.party, _enemies.party, _heros.Inventory);
    if (_enemies.party.Count <= 0)
    {
      return;
    }
    Turn(_enemies.party, _heros.party, _enemies.Inventory);
  }
  
  /// <summary>
  /// Adds inventory to party from start of game
  /// </summary>
  /// <param name="party"></param>
  private void AddInventory(Party party)
  {
    if (party.Equals(_heros))
    {
      party.Inventory.Add(new HealthPotion());
      party.Inventory.Add(new Sword());
      return;
    }
    party.Inventory.Add(new HealthPotion());
  }
}