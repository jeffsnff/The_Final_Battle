namespace FinalBattle;

public class Game
{
    private static bool status;
    public Game()
    {
        status = true;
    }
    
    public void Run()
    {
        List<Character> heros = new List<Character>();
        List<Character> enemies = new List<Character>();

        heros.Add(PickHero());
        enemies.Add(new Character());
        while (status)
        {
            Turn(heros, enemies);
            Turn(enemies, heros);
        }
    }
    
    /// <summary>
    /// Pass in party to represent the parties move
    /// </summary>
    /// <param name="party"></param>
    private static void Turn(List<Character> offense, List<Character> defense)
    {
        foreach (Character member in offense)
        {
            Console.WriteLine(($"It is {member.name}'s turn..."));
            member.Move(defense.First());
            Console.WriteLine();
            
            if (defense.First().currentHP <= 0)
            {
                defense.Remove(defense.First());
            }

            if (defense.Count == 0)
            {
                Console.WriteLine("Game Over!");
                status = false;
            }
            Console.ReadKey();
        } 
    }
    /// <summary>
    /// Allows player to name their hero
    /// </summary>
    /// <returns></returns>
    private static Character PickHero()
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