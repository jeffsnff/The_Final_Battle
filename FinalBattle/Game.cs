namespace FinalBattle;

public class Game
{
    private bool _status = true;
    private int _gameMode;

    public Game(){ }
    
    public void Run()
    {
        List<Character> heroes = new List<Character>();
        List<Character> enemyWaveOne = new List<Character>();
        List<Character> enemyWaveTwo = new List<Character>();
        List<Character> bossBattle = new List<Character>();
        List<List<Character>> enemies = new List<List<Character>>();
        
        // _gameMode = SelectGameMode();
        switch (_gameMode = 3) // Jeffrey remove this number uncomment SelectGameMode() to select manually
        {
            case 1: // Player vs Computer
                heroes.Add(PickHero());
                
                enemyWaveOne.Add(new Skeleton());
                enemyWaveTwo.Add(new Skeleton());
                enemyWaveTwo.Add(new Skeleton());
                enemies.Add(enemyWaveOne);
                enemies.Add(enemyWaveTwo);
                break;
            case 2: // Player vs Player
                heroes.Add(PickHero());
                enemyWaveOne.Add(new Skeleton(false));
                break;
            case 3: // Computer vs Computer
                heroes.Add(PickHero());
                
                enemyWaveOne.Add(new Skeleton());
                enemyWaveTwo.Add(new Skeleton());
                enemyWaveTwo.Add(new Skeleton());
                bossBattle.Add(new UnCodedOne());
                enemies.Add(enemyWaveOne);
                enemies.Add(enemyWaveTwo);
                enemies.Add(bossBattle);
                break;
        }
        
        // Game Loop
        while (enemies.Count > 0 && heroes.Count > 0)
        {
            foreach (List<Character> wave in enemies)
            {
                while (wave.Count > 0)
                {
                    Battle.Turn(heroes, wave);
                    if (wave.Count == 0 || heroes.Count == 0)
                    {
                        break;
                    }
                    Battle.Turn(wave, heroes);
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