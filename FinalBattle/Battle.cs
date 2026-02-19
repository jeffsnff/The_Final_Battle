namespace FinalBattle;

public class Battle
{
  public static void Turn(List<Character> offense, List<Character> defense)
  {
    foreach (Character member in offense)
    {
      Status.currentPlayer = member;
      Status.BattleStatus();
      Console.WriteLine($"It is {member.Name}'s turn...");
      member.Move(member, Enemy_Chooser(defense, member));
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