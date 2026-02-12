using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;

namespace FinalBattle;

public class Status
{
  private static int _width = Console.WindowWidth;
  private static List<Character> Heros { get; set; }
  private static List<Character> Enemies { get; set; }

  public Status(List<Character> heros, List<Character> enemies)
  {
    Heros = heros;
    Enemies = enemies;
  }

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
        border.Remove((border.Length-title.Length));
        border = border + title;
        i = i + title.Length;
      }
    }
    Console.WriteLine(border);
  }

  public void BattleStatus()
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