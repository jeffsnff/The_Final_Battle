namespace FinalBattle;

public static class PlayerInput
{
    /// <summary>
    /// Allows character to choose their move from enum Action in Action.cs
    /// </summary>
    /// <param name="attacker"></param>
    /// <returns></returns>
    public static int UserSelection(Character attacker, List<string> options)
    {
        if (attacker.Ai)
        {
            // Generates a random number based off the number of moves in TurnAction
            // then selects that action that cooresponds to the number.
            Random randomNumber = new Random();
            return randomNumber.Next(options.Count);
        }
        
        while (true)
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
            
            Console.WriteLine("What would you like to do?");
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i} - {options[i]}");
            }

            int.TryParse(Console.ReadLine(), out int index);
            if (0 < index && index < options.Count)
            {
                return index;
            }
            
            Console.WriteLine("That is not an option!");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}