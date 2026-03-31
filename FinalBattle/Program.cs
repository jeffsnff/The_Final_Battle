namespace FinalBattle;

class Program
{
  static void Main(string[] args)
  {
    Console.SetWindowSize(100,100);
    Console.Title = "The Final Battle";
    Game game = new Game();
    game.Run();
  }
}