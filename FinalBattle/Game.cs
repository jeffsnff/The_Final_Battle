namespace FinalBattle;

public class Game
{
    private bool _status = true;
    private int _gameMode;

    public Game(){ }
    
    public void Run()
    {
        List<Character> heroes = new List<Character>();
        List<Character> enemyWave1 = new List<Character>();
        List<Character> enemyWave2 = new List<Character>();
        List<List<Character>> enemieWaves= new List<List<Character>>();
        
        // _gameMode = SelectGameMode();
        switch (_gameMode = 3) // Jeffrey remove this number uncomment SelectGameMode() to select manually
        {
            case 1: // Player vs Computer
                heroes.Add(PickHero());
                
                enemyWave1.Add(new Skeleton());
                enemyWave2.Add(new Skeleton());
                enemyWave2.Add(new Skeleton());
                enemieWaves.Add(enemyWave1);
                enemieWaves.Add(enemyWave2);
                break;
            case 2: // Player vs Player
                heroes.Add(PickHero());
                enemyWave1.Add(new Skeleton(false));
                break;
            case 3: // Computer vs Computer
                heroes.Add(PickHero());
                
                enemyWave1.Add(new Skeleton());
                enemyWave2.Add(new Skeleton());
                enemyWave2.Add(new Skeleton());
                enemieWaves.Add(enemyWave1);
                enemieWaves.Add(enemyWave2);
                break;
        }
        
        // Game Loop
        while (enemieWaves.Count > 0)
        {
            foreach (List<Character> wave in enemieWaves)
            {
                while (wave.Count > 0)
                {
                    Battle.Turn(heroes, wave);
                    if (wave.Count == 0)
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