using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;

namespace FinalBattle;

public static class Status
{
  private static int _width = Console.WindowWidth;
  public static List<Character> Heros { get; set; }
  public static List<Character> Enemies { get; set; }

  private static void CreateBorder(string symbol)
  {
    string border = "";
    for (int i = 1; i < _width; i++)
    {
      border = border + symbol;
    }
    Console.WriteLine(border);
  }

  private static void TopBorder()
  {
    string border = "";
    string title = " BATTLE ";
    for (int i = 1; i < _width; i++)
    {
      border = border + "=";
      if (border.Length == (_width / 2))
      {
        border = border.Remove((border.Length - title.Length));
        border = border + title;
        // i = i + title.Length;
      }
    }
    Console.WriteLine(border);
  }

  public static void BattleStatus()
  {
    TopBorder();
    foreach (Character member in Heros)
    {
      Console.WriteLine($"{member.Name} ({member.Health}/{member.MaxHP})");
    }
    Console.WriteLine();
    foreach (Character member in Enemies)
    {
      Console.WriteLine($"{member.Name} ({member.Health}/{member.MaxHP})");
    }
    CreateBorder("=");
  }
}