namespace FinalBattle;

public static class PlayerInput
{
    /// <summary>
    /// Allows character to choose what they want from a list of options
    /// </summary>
    /// <param name="attacker"></param>
    /// <param name="options"></param>
    /// <param name="question"></param>
    /// <returns></returns>
    public static int UserSelection(Character attacker, List<string> options, string question)
    {
        while (true)
        {
            BattleUI.BattleStatus();
            if (attacker.Ai)
            {
                // Generates a random number based off the number of items in options
                Random randomNumber = new Random();
                return randomNumber.Next(options.Count);
            }
            
            // Clears any accidental key press
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
            
            Console.WriteLine(question);
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i} - {options[i]}");
            }

            int.TryParse(Console.ReadLine(), out int index);
            if (0 <= index && index < options.Count)
            {
                return index;
            }
            
            Console.WriteLine("That is not an option!");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}