namespace FinalBattle;

public class Game
{
  private bool _status = true;
  private int _gameMode;

  public Game() { }

  public void Run()
  {
    Party heros = new Party();
    Party enemyWaveOne = new Party();
    Party enemyWaveTwo = new Party();
    Party bossBattle = new Party();
    List<Party> enemies = new List<Party>();

    // _gameMode = SelectGameMode();
    switch (_gameMode = 3) // Jeffrey remove this number uncomment SelectGameMode() to select manually
    {
      case 1: // Player vs Computer
        heros.Add = PickHero();
        
        enemyWaveOne.Add = new Skeleton();
        enemyWaveTwo.Add = new Skeleton();
        enemyWaveTwo.Add = new Skeleton();
        enemies.Add(enemyWaveOne);
        enemies.Add(enemyWaveTwo);
        break;
      case 2: // Player vs Player
        heros.Add = PickHero();

        enemyWaveOne.Add = new Skeleton();
        break;
      case 3: // Computer vs Computer
        heros.Add = PickHero();

        enemyWaveOne.Add = new Skeleton();
        enemyWaveTwo.Add = new Skeleton();
        enemyWaveTwo.Add = new Skeleton();
        bossBattle.Add = new UnCodedOne();
        enemies.Add(enemyWaveOne);
        enemies.Add(enemyWaveTwo);
        enemies.Add(bossBattle);
        break;
    }

    // Game Loop
    while (enemies.Count > 0 && heros.Count > 0)
    {
      foreach (Party wave in enemies)
      {
        Battle battle = new Battle(heros, wave);
        while (wave.Count > 0)
        {
          if (wave.Count == 0 || heros.Count == 0)
          {
            break;
          }
          battle.ExecuteBattle();
        }
      }

      break;
    }
    GameOver();
  }

  private static void GameOver()
  {
    Console.WriteLine("Game Over!");
    Console.ReadKey();
  }

  /// <summary>
  /// User select which game mode they want
  /// Options are;
  /// 1. Player vs Computer
  /// 2. Player vs Player
  /// 3. Computer vs Computer
  /// </summary>
  /// <returns></returns>
  private static int SelectGameMode()
  {
    Console.WriteLine("Choose how you want to play the game:");
    Console.WriteLine("1: Player vs Computer");
    Console.WriteLine("2: Player vs Player");
    Console.WriteLine("3: Computer vs Computer");

    if (int.TryParse(Console.ReadLine(), out int mode))
    {
      return mode;
    }

    return 1;
  }

  /// <summary>
  /// Allows player to name their hero
  /// </summary>
  /// <returns>TruProgrammer Class</returns>
  private TrueProgrammer PickHero(string player = "Player")
  {
    if (_gameMode.Equals(3))
    {
      return new TrueProgrammer("TOG", true);
    }
    while (true)
    {
      Console.Write($"Name your hero: ");
      string? heroName = Console.ReadLine();
      if (!String.IsNullOrEmpty(heroName))
      {
        return new TrueProgrammer(heroName);
      }
      Console.WriteLine("The hero needs a name!");
      Console.ReadKey();
      Console.Clear();
    }
  }
}