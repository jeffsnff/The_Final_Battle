namespace FinalBattle;

public class Game
{
    private bool _status = true;
    public Game() { }
    
    public void Run()
    {
        List<Character> heroes = new List<Character>();
        List<Character> enemies = new List<Character>();

        heroes.Add(PickHero());
        enemies.Add(new Character());
        while (_status)
        {
            Battle battle = new Battle();
            _status = battle.Turn(heroes, enemies, _status);
            _status = battle.Turn(enemies, heroes, _status);
        }
    }
    
    /// <summary>
    /// Allows player to name their hero
    /// </summary>
    /// <returns></returns>
    private Character PickHero()
    {
        while (true)
        {
            Console.Write("Name your hero: ");
            string? heroName = Console.ReadLine();
            if (!String.IsNullOrEmpty(heroName))
            {
                return new Character(heroName, false, true);
            }
            Console.WriteLine("The hero needs a name!");
            Console.ReadKey();
            Console.Clear();
        }
    }
}