namespace FinalBattle;

public static class PlayerInput
{
    /// <summary>
    /// Allows character to choose their move from enum Action in Action.cs
    /// </summary>
    /// <param name="attacker"></param>
    /// <returns></returns>
    public static Action Move(Character attacker)
    {
        Random randomNumber = new Random();
  
        if (attacker.Ai)
        {
            // Generates a random number based off the number of moves in TurnAction
            // then selects that action that cooresponds to the number.
            return attacker.CurrentAttack = (Action)randomNumber.Next(Enum.GetNames<Action>().Length);
        }
        string[] actions = Enum.GetNames<Action>();
        while (true)
        {
            Console.WriteLine("What would you like to do?");
            for (int i = 0; i < actions.Length; i++)
            {
                if ((i+1) == actions.Length && !attacker.Armor.Any())
                {
                    break;
                }
                Console.WriteLine($"{i} - {actions[i]}");
            }
  
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                if (!(index > actions.Length))
                {
                    return attacker.CurrentAttack = Enum.GetValues<Action>().ElementAt(index);
                }
            }
            Console.WriteLine("That is not an option!");
            Console.ReadKey();
        }
    }
}