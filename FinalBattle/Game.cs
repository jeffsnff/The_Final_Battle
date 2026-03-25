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
    List<Party> enemyArmy = new List<Party>();

    // _gameMode = SelectGameMode();
    switch (_gameMode = 3) // Jeffrey remove this number uncomment SelectGameMode() to select manually
    {
      case 1: // Player vs Computer
        heros.party.Add(PickHero());
        enemyWaveOne.party.Add(new Skeleton());
        enemyWaveTwo.party.Add(new Skeleton());
        enemyWaveTwo.party.Add(new Skeleton());
        enemyWaveTwo.party.Add(new Skeleton());
        enemyArmy.Add(enemyWaveOne);
        enemyArmy.Add(enemyWaveTwo);
        StoryTime(heros.party[0].Name);
        break;
      case 2: // Player vs Player
        heros.party.Add(PickHero());
        enemyWaveOne.party.Add(new Skeleton());
        StoryTime(heros.party[0].Name);
        break;
      case 3: // Computer vs Computer
        heros.party.Add(PickHero());

        enemyWaveOne.party.Add(new Skeleton());
        enemyWaveTwo.party.Add(new Skeleton());
        enemyWaveTwo.party.Add(new Skeleton());
        bossBattle.party.Add(new UnCodedOne());
        enemyArmy.Add(enemyWaveOne);
        enemyArmy.Add(enemyWaveTwo);
        enemyArmy.Add(bossBattle);
        break;
    }

    // Game Loop
    while (enemyArmy.Count > 0 && heros.party.Count > 0)
    {
      foreach (Party wave in enemyArmy)
      {
        Battle battle = new Battle(heros, wave);
        while (wave.party.Count > 0)
        {
          if (wave.party.Count == 0 || heros.party.Count == 0)
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

  private void StoryTime(string playerName)
  {
    Console.Clear();
    Console.WriteLine("You make your way to the Uncoded One Fortress.");
    Console.WriteLine("The height of the fortress is so large you see birds fly near the top of the spires.");
    Thread.Sleep(8000);
    Console.WriteLine();
    Console.WriteLine("Walking up to the entrance, the ground beneath you starts to tremble.");
    Console.WriteLine("Slowly, the massive doors leading inside start to open, revealing a pitch black entry.");
    Console.WriteLine("Out of the darkness comes a voice, loud and deep...");
    Console.WriteLine($"Enter {playerName}. It is your time to die!");
    Thread.Sleep(8000);
    Console.WriteLine();
    Console.WriteLine("You stop in your tracks... scared...");
    Console.WriteLine("Taking a deep breath, you remember all the people that you helped. Remembering all the good in this land.");
    Console.WriteLine("Press key to continue...");
    Console.ReadKey();
    Console.WriteLine("Breathing out slowly you continue on...");
    Thread.Sleep(3000);
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