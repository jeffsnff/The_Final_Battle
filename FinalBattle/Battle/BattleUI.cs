namespace FinalBattle;

public static class BattleUI
{
  private static readonly int Width = Console.WindowWidth;
  public static List<Character> Heros { get; set; }
  public static List<Character> Enemies { get; set; }
  public static Character currentPlayer { get; set; }

  private static void CreateBorder(string symbol = "=", string word = "")
  {
    string border = "";
    string title = word;
    for (int i = 1; i < Width; i++)
    {
      border = border + symbol;
      if (border.Length == (Width / 2))
      {
        border = border + title;
        i = i + title.Length;
      }
    }
    Console.WriteLine($"{border}");
  }

  private static void CharacterInfo(Character member)
  {
    string text = $"{member.Name} ({member.CurrentHp}/{member.MaxHp})";
    if (Enemies.Contains(member))
    {
      Console.CursorLeft = Width - (text.Length + 1);
    }
    if (member == currentPlayer)
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

  /// <summary>
  /// Creates the UI for the battle
  /// </summary>
  public static void BattleStatus()
  {
    Console.Clear();
    CreateBorder("=", " BATTLE ");
    foreach (Character member in Heros)
    {
      CharacterInfo(member);
    }
    CreateBorder("-", " VS ");
    foreach (Character member in Enemies)
    {
      CharacterInfo(member);
    }
    CreateBorder();
  }
}