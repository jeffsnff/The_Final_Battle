namespace FinalBattle;

class Program
{
    static void Main(string[] args)
    {
        
        // Console.WriteLine("Choose how you want to play the game:");
        // Console.WriteLine("1: Player vs Computer");
        // Console.WriteLine("2: Player vs Player");
        // Console.WriteLine("3: Computer vs Computer");

        Game game = new Game();
        game.Run();

        // if (int.TryParse(Console.ReadLine(), out int gameMode))
        // {
        //     Game game = new Game(gameMode);
        //     game.Run();
        // }
        // else
        // {
        //     Game game = new Game(1);
        // }
    }
}