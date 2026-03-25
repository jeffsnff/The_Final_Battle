namespace FinalBattle;

public static class EnemyChooser
{
    /// <summary>
    /// Allows user to select an ememy to attack
    /// </summary>
    /// <param name="member"></param>
    /// <param name="enemies"></param>
    /// <returns></returns>
    public static Character SelectEnemy(Character member, List<Character> enemies)
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
}