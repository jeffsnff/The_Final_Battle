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

    _gameMode = SelectGameMode();
    switch (_gameMode)
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
  /// User selects which game mode they want
  /// </summary>
  /// <returns></returns>
  private static int SelectGameMode()
  {
    while (true)
    {
      Console.WriteLine("Choose how you want to play the game:");
      Console.WriteLine("1: Player vs Computer");
      Console.WriteLine("2: Player vs Player");
      Console.WriteLine("3: Computer vs Computer");
      
      int.TryParse(Console.ReadLine(), out int mode);
      switch (mode)
      {
        case 3:
          return 3;
        case 2:
          return 2;
        default:
          return 1;
      }
    }
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
    while (Console.KeyAvailable)
    {
      Console.ReadKey(false);
    }
    Console.WriteLine("Press key to continue...");
    Console.ReadKey();
    Console.WriteLine("Breathing out slowly you continue on...");
    Thread.Sleep(3000);
  }

  /// <summary>
  /// Allow user to choose their characters name. Default "Player"
  /// </summary>
  /// <returns>String : Player chosen name</returns>
  private TrueProgrammer PickHero()
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