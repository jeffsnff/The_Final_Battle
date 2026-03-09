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
    Status.Enemies = _enemies.Members;
    Status.Heros = _heros.Members;
    
    Turn(_heros.Members, _enemies.Members, _heros._inventory);
    if (_enemies.Count <= 0)
    {
      return;
    }
    Turn(_enemies.Members, _heros.Members, _enemies._inventory);
  }
  private void Turn(List<Character> offense, List<Character> defense, List<Item> inventory)
  {
    foreach (Character member in offense)
    {
      _attacker = member;
      Status.currentPlayer = _attacker;
      Status.BattleStatus();
      Console.WriteLine($"It is {member.Name}'s turn...");
      member.ChooseMove();

      switch (_attacker.CurrentAttack)
      {
        case Character.Action.Attack:
          _defender = Enemy_Chooser(defense, member);
          member.PerformAction(_attacker.CurrentAttack, _defender);
          break;
        case Character.Action.Nothing:
          Console.WriteLine($"{_attacker} did NOTHING.");
          break;
        case Character.Action.Inventory:
          Console.WriteLine($"{_attacker} checks backpack.");
          if (inventory.Count==0)
          {
            Console.WriteLine("Backpack is empty!");
            break;
          }

          for (int i = 0; i < inventory.Count; i++)
          {
            Console.WriteLine($"{i} - {inventory[i]}");
          }
          Console.WriteLine("What would you like to take? (enter number)");
          if (int.TryParse(Console.ReadLine(), out int userSelection))
          {
            if (inventory[userSelection].ToString() == "Health Potion")
            {
              HealthPotion potion = (HealthPotion)inventory[userSelection];
              Console.WriteLine("You take the health potion!");
              int temp = _attacker.Health + potion.Take();
              if (temp > _attacker.MaxHP)
              {
                _attacker.Health = _attacker.MaxHP;
              }
              else
              {
                _attacker.Health += potion.Take();
              }
              inventory.Remove(inventory[userSelection]);
            }
          }
          break;
      }

      Thread.Sleep(3000);
      Console.WriteLine();
      DeathMechanic(defense);
      // Console.Clear();
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
  private static bool GameStatus(List<Character> defense)
  {
    if (defense.Count == 0)
    {
      return false;
    }
    return true;
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