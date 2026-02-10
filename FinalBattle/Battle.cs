namespace FinalBattle;

public class Battle
{
  public static void Turn(List<Character> offense, List<Character> defense)
  {
    foreach (Character member in offense)
    {
      Console.WriteLine(($"It is {member.Name}'s turn..."));

      if (member.Ai)
      {
        member.Move(member, defense.First());
      }
      else
      {
        member.Move(member, Enemy_Chooser(defense));
      }
      Console.WriteLine();
      Death(defense);
    }
    // return GameStatus(defense);
  }

  private static Character Enemy_Chooser(List<Character> enemies)
  {
    // Console.WriteLine("What enemy would you like to attack?");
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