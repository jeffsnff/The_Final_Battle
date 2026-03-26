using static FinalBattle.PlayerInput;

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
    List<string> enemyNames = new List<string>();
    foreach (Character enemy in enemies)
    {
      enemyNames.Add(enemy.Name);
    }

    int enemyNumber = UserSelection(member, enemyNames, "What enemy would you like to attack?");
    return enemies[enemyNumber];
  }
}