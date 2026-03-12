using static FinalBattle.TurnAction;

namespace FinalBattle;

public class Battle
{
  private Party _heros;
  private Party _enemies;
  private static Character _attacker;
  private static Character _defender;

  public Battle(Party heros, Party enemies)
  {
    _heros = heros;
    _enemies = enemies;
  }

  public void ExecuteBattle()
  {
    Status.Enemies = _enemies.party;
    Status.Heros = _heros.party;
    
    Turn(_heros.party, _enemies.party, _heros.Inventory);
    if (_enemies.party.Count <= 0)
    {
      return;
    }
    Turn(_enemies.party, _heros.party, _enemies.Inventory);
  }
  private void Turn(List<Character> offense, List<Character> defense, List<Item> inventory)
  {
    foreach (Character member in offense)
    {
      _attacker = member;
      Status.currentPlayer = _attacker;
      Status.BattleStatus();
      Console.WriteLine($"It is {member.Name}'s turn...");
      ChooseMove(_attacker);

      switch (_attacker.CurrentAttack)
      {
        case Attack:
          _defender = Enemy_Chooser(defense, member);
          PerformAction(_attacker, _defender);
          break;
        case Nothing:
          Console.WriteLine($"{_attacker.Name} did NOTHING.");
          break;
        case Inventory:
          Console.WriteLine($"{_attacker.Name} checks backpack.");
          CheckInventory(inventory);
          break;
      }

      Thread.Sleep(3000);
      Console.WriteLine();
      DeathMechanic(defense);
      // Console.Clear();
    }
    void ChooseMove(Character attacker)
    {
      Random randomNumber = new Random();
  
      if (attacker.Ai)
      {
        // Generates a random number based off the number of moves in _Action
        // then selects that action that cooresponds to the number.
        attacker.CurrentAttack = (TurnAction)randomNumber.Next(Enum.GetNames<TurnAction>().Length);
        return;
      }
      string[] actions = Enum.GetNames<TurnAction>();
      while (true)
      {
        Console.WriteLine("What would you like to do?");
        for (int i = 0; i < actions.Length; i++)
        {
          Console.WriteLine($"{i} - {actions[i]}");
        }
  
        if (int.TryParse(Console.ReadLine(), out int index))
        {
          if (!(index > actions.Length))
          {
            attacker.CurrentAttack = Enum.GetValues<TurnAction>().ElementAt(index);
            break;
          }
        }
        Console.WriteLine("That is not an option!");
        Console.ReadKey();
      }
    }
    void PerformAction(Character attacker, Character defender = null)
    {
      // Attack name and damage from IAttack
      string attackName = attacker.Attack.Name;
      int attackDamage = attacker.Attack.Damage;
      
      if (attacker.CurrentAttack == Attack)
      {
        defender.Health = (defender.Health - attackDamage);
        string attackerName = attacker.Name;
        string defenderName = defender.Name;
        int defenderMaxHeath = defender.MaxHp;
        int defenderCurrentHealth = defender.Health;
        
        Console.WriteLine($"{attackerName} used {attackName} on {defenderName}.");
        Console.WriteLine($"{attackName} dealt {attackDamage} damage to {defenderName}");
        string playerUpdate = defenderCurrentHealth == 0 ? $"{defenderName} has died!" : $"{defenderName} is now {defenderCurrentHealth}/{defenderMaxHeath}";
        Console.WriteLine(playerUpdate);
      }
    }
  }
  
  private static Character Enemy_Chooser(List<Character> enemies, Character member)
  {
    
    if (member.Ai)
    {
      Random random = new Random();
      int index = random.Next(enemies.Count);
      return enemies[index];
    }
    
    for (int i = 0; i < enemies.Count; i++)
    {
      Console.WriteLine($"{i} : {enemies[i].Name}");
    }
    
    Console.Write("Enemy to attack (Input a number): ");
    if (int.TryParse(Console.ReadLine(), out int enemyNumber))
    {
      if (enemyNumber > (enemies.Count - 1) || enemyNumber < 0)
      {
        return enemies[0];
      }
      return enemies[enemyNumber];
    }
    return enemies[0];
  }
  private static void CheckInventory(List<Item> inventory)
  {
    if (inventory.Count==0)
    {
      Console.WriteLine("Backpack is empty!");
      return;
    }

    if (_attacker.Ai)
    {
      Random random = new Random();
      TakeHealth(inventory, random.Next(inventory.Count()));
      return;
    }

    if (!_attacker.Ai)
    {
      for (int i = 0; i < inventory.Count; i++)
      {
        Console.WriteLine($"{i + 1} - {inventory[i]}");
      }
      Console.WriteLine("What would you like to take? (enter number)");
      if (int.TryParse(Console.ReadLine(), out int userSelection))
      {
        TakeHealth(inventory, userSelection);
      }
    }
    
    static void TakeHealth(List<Item> inventory, int selection)
    {
      if (inventory[selection].ToString() == "Health Potion")
      {
        HealthPotion potion = (HealthPotion)inventory[selection];
        Console.WriteLine($"{_attacker.Name} takes the health potion!");
        int temp = _attacker.Health + potion.Take();
        if (temp > _attacker.MaxHp)
        {
          _attacker.Health = _attacker.MaxHp;
        }
        else
        {
          _attacker.Health += potion.Take();
        }
        inventory.Remove(inventory[selection]);
      }
    }
  }
  private static void DeathMechanic(List<Character> defense)
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