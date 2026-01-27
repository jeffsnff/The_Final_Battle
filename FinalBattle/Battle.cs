namespace FinalBattle;

public class Battle
{
    public Battle(){  }
    
    public bool Turn(List<Character> offense, List<Character> defense, bool status)
    {
        foreach (Character member in offense)
        {
            Console.WriteLine(($"It is {member.Name}'s turn..."));
            member.Move(defense.First());
            Console.WriteLine();
            
            if (defense.First().Health <= 0)
            {
                defense.Remove(defense.First());
            }

            if (defense.Count == 0)
            {
                Console.WriteLine("Game Over!");
                status = false;
            }
            // Console.ReadKey();
        } 
        return status;
    }
}