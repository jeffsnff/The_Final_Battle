namespace FinalBattle;

public static class DeathMechanic
{
    public static void DeathHandler(List<Character> defense)
    {
        for (int i = 0; i < defense.Count; i++)
        {
            if (defense[i].Health <= 0)
            {
                defense.Remove(defense[i]);
            }
        }
    }
}