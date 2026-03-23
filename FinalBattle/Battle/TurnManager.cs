using static FinalBattle.Action;
using static FinalBattle.EnemyChooser;
using static FinalBattle.InventoryManager;
using static FinalBattle.DeathMechanic;
using static FinalBattle.CharacterAttack;

namespace FinalBattle;

public static class TurnManager
{
  public static void Turn(List<Character> offense, List<Character> defense, List<Item> inventory)
  {
    foreach (Character member in offense)
    {
      Character attacker = member;
      BattleUI.currentPlayer = attacker;
      BattleUI.BattleStatus();
      Console.WriteLine($"It is {member.Name}'s turn...");
      attacker.CurrentAttack = PlayerInput.Move(attacker);

      switch (attacker.CurrentAttack)
      {
        case Action.Attack:
          Character defender = SelectEnemy(member, defense);
          Attack(attacker, defender);
          break;
        case Nothing:
          Console.WriteLine($"{attacker.Name} did NOTHING.");
          break;
        case Inventory:
          Console.WriteLine($"{attacker.Name} checks backpack.");
          CheckInventory(inventory, attacker);
          break;
        case Special:
          Character defenderr = SelectEnemy(member, defense);
          Attack(attacker, defenderr);
          break;
      }
      DeathHandler(defense);
      Thread.Sleep(3000);
      Console.WriteLine();
    }
  }
}