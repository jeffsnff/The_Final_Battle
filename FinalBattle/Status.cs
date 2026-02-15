using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;

namespace FinalBattle;

public static class Status
{
  private static readonly int Width = Console.WindowWidth;
  public static List<Character> Heros { get; set; }
  public static List<Character> Enemies { get; set; }
  public static Character currentPlayer { get; set; }

  private static void CreateBorder(string symbol, string word = "")
  {
    string border = "";
    string title = word;
    for (int i = 1; i < Width; i++)
    {
      border = border + symbol;
      if (border.Length == (Width / 2))
      {
        // border = border.Remove((border.Length - title.Length));
        border = border + title;
        i = i + title.Length;
      }
    }
    Console.WriteLine($"\n{border}\n");
  }

  public static void BattleStatus()
  {
    CreateBorder("=", " BATTLE ");
    foreach (Character member in Heros)
    {
      if(member == currentPlayer)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{member.Name} ({member.Health}/{member.MaxHP})");
        Console.ResetColor();
      }
      else
      {
        Console.WriteLine($"{member.Name} ({member.Health}/{member.MaxHP})");
      }
      
    }
    CreateBorder("-", " VS ");
    foreach (Character member in Enemies)
    {
      string text = $"{member.Name} ({member.Health}/{member.MaxHP})";
      Console.CursorLeft = Width - (text.Length) - 1;
      if(member == currentPlayer)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ResetColor();
      }
      else
      {
        Console.WriteLine(text);
      }
      
    }
    CreateBorder("=");
  }
}