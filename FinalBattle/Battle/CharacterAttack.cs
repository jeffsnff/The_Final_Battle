using static FinalBattle.Action;

namespace FinalBattle;

public static class CharacterAttack
{
    /// <summary>
    /// Character Attack action. Will check to see if character selected special attack and update attack power accordingly
    /// </summary>
    /// <param name="attacker"></param>
    /// <param name="defender"></param>
    public static void Attack(Character attacker, Character defender = null)
    {
        // Attack name and damage from IAttack
        string attackName = attacker.Attack.Name;
        int attackDamage = attacker.Attack.Damage;

        // Updates attackDamage and attackname when user selects Special attack
        if (attacker.CurrentAttack.Equals(Special))
        {
            foreach (var (key,value) in attacker.Armor)
            {
                switch (key)
                {
                    case GearType.Sword:
                        attackDamage = value.Attack;
                        attackName = value.Name;
                        break;
                }
            }
        }
      
        defender.TakeDamage(attackDamage);
        string attackerName = attacker.Name;
        string defenderName = defender.Name;
        int defenderMaxHeath = defender.MaxHp;
        int defenderCurrentHealth = defender.CurrentHp;
      
        Console.WriteLine($"{attackerName} used {attackName} on {defenderName}.");
        Console.WriteLine($"{attackName} dealt {attackDamage} damage to {defenderName}");
        string playerUpdate = defenderCurrentHealth == 0 ? $"{defenderName} has died!" : $"{defenderName} is now {defenderCurrentHealth}/{defenderMaxHeath}";
        Console.WriteLine(playerUpdate);
    }
}