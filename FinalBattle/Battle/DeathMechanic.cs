namespace FinalBattle;

public static class DeathMechanic
{
    /// <summary>
    /// Removes character from party if health is equal or less than 0
    /// </summary>
    /// <param name="defense"></param>
    public static void DeathHandler(List<Character> defense)
    {
        for (int i = 0; i < defense.Count; i++)
        {
            if (defense[i].CurrentHp <= 0)
            {
                defense.Remove(defense[i]);
            }
        }
    }
}