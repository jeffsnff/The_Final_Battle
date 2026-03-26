using static FinalBattle.PlayerInput;

namespace FinalBattle;

public static class ActionChooser
{
    /// <summary>
    /// Allows character to choose their move from enum Action in Action.cs
    /// </summary>
    /// <param name="attacker"></param>
    /// <returns></returns>
    public static Action Action(Character attacker)
    {
        List<string> enumOptions = Enum.GetNames<Action>().ToList();
        
        if (!attacker.Armor.Any())
        { 
            enumOptions.Remove("Special");
        }

        int index = UserSelection(attacker, enumOptions, "What would you like to do?");
        
        return attacker.CurrentAttack = Enum.GetValues<Action>().ElementAt(index);
    }
}