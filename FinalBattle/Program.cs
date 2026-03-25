namespace FinalBattle;

class Program
{
  static void Main(string[] args)
  {
    Console.SetWindowSize(100,100);
    
    Console.WriteLine("The Final Battle");

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