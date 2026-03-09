namespace FinalBattle;

public class Battle
{
  private Party _heros;
  private Party _enemies;
  private static Character _attacker;
  private static Character _defender;
  private static Character.Action currentAttack;

  public Battle(Party heros, Party enemies)
  {
    _heros = heros;
    _enemies = enemies;
  }

  public void ExecuteBattle()
  {
    Status.Enemies = _enemies.Members;
    Status.Heros = _heros.Members;
    Turn(_heros.Members, _enemies.Members);
    if (_enemies.Count <= 0)
    {
      return;
    }
    Turn(_enemies.Members, _heros.Members);
  }
  private void Turn(List<Character> offense, List<Character> defense)
  {
    foreach (Character member in offense)
    {
      _attacker = member;
      Status.currentPlayer = _attacker;
      Status.BattleStatus();
      Console.WriteLine($"It is {member.Name}'s turn...");
      currentAttack = member.ChooseMove();
      
      if (_attacker.CurrentAttack.Equals(Character.Action.Attack))
      {
        _defender = Enemy_Chooser(defense, member);
        member.PerformAction(_attacker.CurrentAttack, _defender);
      }
      else
      {
        member.PerformAction(_attacker.CurrentAttack);
      }
      
      Console.WriteLine();
      Death(defense);
      // Console.Clear();
    }
  }
  private static Character Enemy_Chooser(List<Character> enemies, Character member)
  {
    
    if (member.Ai)
    {
      Random random = new Random();
      int index = random.Next(enemies.Count);
      return enemies[index];
    }
    
    for (int i = 0; i < enemies.Count; i++)
    {
      Console.WriteLine($"{i} : {enemies[i].Name}");
    }
    
    Console.Write("Enemy to attack (Input a number): ");
    if (int.TryParse(Console.ReadLine(), out int enemyNumber))
    {
      if (enemyNumber > (enemies.Count - 1) || enemyNumber < 0)
      {
        return enemies[0];
      }

      return enemies[enemyNumber];
    }
    return enemies[0];
  }
  private static bool GameStatus(List<Character> defense)
  {
    if (defense.Count == 0)
    {
      return false;
    }
    return true;
  }

  private static void Death(List<Character> defense)
  {
    for (int i = 0; i < defense.Count; i++)
    {
      if (defense[i].Health <= 0)
      {
        defense.Remove(defense[i]);
      }
    }
  }
}