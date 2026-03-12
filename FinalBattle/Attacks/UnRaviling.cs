namespace FinalBattle;

public class UnRaviling : IAttack
{
    public string Name => "UNRAVILING";
    public int Damage => DamageAmount();
    
    private static int DamageAmount()
    {
        Random random = new Random();
        return random.Next(4);
    }
}