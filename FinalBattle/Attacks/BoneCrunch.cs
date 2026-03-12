namespace FinalBattle;

public class BoneCrunch : IAttack
{
    public string Name => "BONE CRUNCH";
    public int Damage => DamageAmount();
    private static int DamageAmount()
    {
        Random random = new Random();
        return random.Next(2);
    }
}