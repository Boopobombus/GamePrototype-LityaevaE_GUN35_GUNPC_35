using GamePrototype.Dungeon;
using GamePrototype.Units;
using System.Security.Cryptography;

namespace GamePrototype.Combat
{
    public sealed class CombatManager
    {
        private readonly Random _random = new();
        
        public Unit StartCombat(Unit player, Unit enemy) => PlayCombatRoutine(player, enemy);

        private Unit PlayCombatRoutine(Unit player, Unit enemy)
        {
            Console.WriteLine(GetCombatString());
            while (player.Health > 0 && enemy.Health > 0) 
            {
                if (Enum.TryParse<RockPaperScissors>(Console.ReadLine(), out var rockPaperScissors)) 
                {
                    HandleCombatInput(player, enemy, rockPaperScissors);
                }
                else
                {
                    Console.WriteLine(GetCombatString());
                }
            }
            if (player.Health > 0 && enemy.Health == 0) 
            {
                return player;
            }
            else if (player.Health == 0 && enemy.Health > 0) 
            {
                return enemy;
            }

            return null;
        }

        private string GetCombatString() => $"Type {RockPaperScissors.Rock} = {(int)RockPaperScissors.Rock}" +
            $"or {RockPaperScissors.Paper} = {(int)RockPaperScissors.Paper}" +
            $"or {RockPaperScissors.Scissors} = {(int)RockPaperScissors.Scissors}";

        private void HandleCombatInput(Unit player, Unit enemy, RockPaperScissors rockPaperScissors)
        {
            var enemyInput = (RockPaperScissors) _random.Next(1, 3);
            Console.WriteLine($"Result player = {rockPaperScissors} and enemy = {enemyInput}");
            switch (rockPaperScissors) 
            {
                // player hit
                case RockPaperScissors.Rock when enemyInput == RockPaperScissors.Scissors:
                    ApplyDamage(player, enemy);
                    ArmorDamage(player, enemy);
                    break;
                case RockPaperScissors.Scissors when enemyInput == RockPaperScissors.Paper:
                    ApplyDamage(player, enemy);
                    ArmorDamage(player, enemy);
                    break;
                case RockPaperScissors.Paper when enemyInput == RockPaperScissors.Rock:
                    ApplyDamage(player, enemy);
                    ArmorDamage(player, enemy);
                    break;
                // enemy hit
                case RockPaperScissors.Scissors when enemyInput == RockPaperScissors.Rock:
                    ApplyDamage(enemy, player);
                    ArmorDamage(enemy, player);
                    break;
                case RockPaperScissors.Paper when enemyInput == RockPaperScissors.Scissors:
                    ApplyDamage(enemy, player);
                    ArmorDamage(enemy, player);
                    break;
                case RockPaperScissors.Rock when enemyInput == RockPaperScissors.Paper:
                    ApplyDamage(enemy, player);
                    ArmorDamage(enemy, player);
                    break;
                default:
                    Console.WriteLine("Combatants tried to hit, but missed :(");
                    break;
            }
        }

        private void ApplyDamage(Unit attacker, Unit defender)
        {
            defender.ApplyDamage(attacker.GetUnitDamage());
                        Console.WriteLine($"{attacker.Name} hits {defender.Name}. {defender.Name} health {defender.Health}/{defender.MaxHealth}");
            Console.WriteLine($"Базовый урон - {attacker.baseDamage}");
            Console.WriteLine($"Урон с уровнем сложности  - {attacker.GetUnitDamage()}");
            if (defender.Health == 0) 
            {
                Console.WriteLine($"{defender.Name} is dead!");
            }
        }

        private void ArmorDamage(Unit attacker, Unit defender)
        {
            defender.ArmorDamage(attacker.GetUnitDamage());
            Console.WriteLine($"{attacker.Name} hits {defender.Name}. {defender.Name} Armor {defender.Armour}");
        }

        
    }
}
