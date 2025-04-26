using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.IO;

namespace DungeonExplorer
{
    /*
    * Description:
    * This is the main class that runs the game. It controls how the game starts,
    * what happens in each room, how the player moves, fights, picks up items,
    * uses healing, solves puzzles, and saves or ends the game.
    
    * Main Functionality:
    * - Lets the player explore rooms and interact with them.
    * - Handles movement, picking items, using items, and fighting monsters.
    * - Uses saving and loading so players can continue later.
    * - Uses interface (IDamageable) and inheritance for how damage works.
    * - Also uses overloaded methods (Heal) and basic monster AI reactions.
    
    * Input Parameters:
    * - Player input from console for making choices
    
    * Expected Output:
    * - Room descriptions, health updates, combat messages, inventory updates, etc.
    */

    public class Game
    {
        private Player player;            // the player character
        private GameMap map;              // handles rooms and navigation
        private Statistics stats;         // tracks score, damage, items, etc.
        private bool playing = true;      // keeps the game running

        // sets up the game: load from save or start new
        public Game()
        {
            Console.Write("Load previous save? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                stats = Statistics.Load(out string name, out int health);
                player = new Player(name, health);
            }
            else
            {
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                player = new Player(name, 100);
                stats = new Statistics();
            }

            map = new GameMap();
            Console.WriteLine($"\nWelcome, {player.Name}. Your quest begins!");
        }

        // the main loop — player chooses what to do each turn
        public void Start()
        {
            while (playing)
            {
                Console.WriteLine("\n1. View Room Info\n2. Pick Up Item\n3. Use Item\n4. Move\n5. Fight\n6. Inventory\n7. Exit and See Statistics");
                Console.WriteLine("8. Save Game");
                Console.WriteLine("9. Heal (Overloaded Method)");
                Console.Write("Choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine(map.CurrentRoom.GetInfo());
                        break;

                    case "2":
                        // pick up all items in the room
                        if (map.CurrentRoom.Items.Count == 0)
                        {
                            Console.WriteLine("There are no more items to pick up.");
                        }
                        else
                        {
                            foreach (var item in map.CurrentRoom.Items.ToList())
                            {
                                player.PickUpItem(item);
                            }
                            map.CurrentRoom.Items.Clear();
                        }
                        break;

                    case "3":
                        // use an item from your inventory
                        Console.Write("Item to use: ");
                        string itemName = Console.ReadLine();
                        player.UseItem(itemName, stats);
                        break;

                    case "4":
                        // move to the next room and check for traps or puzzles
                        if (map.MoveToNextRoom())
                        {
                            if (map.CurrentRoom.HasTrap)
                            {
                                Console.WriteLine("Ouch! You triggered a trap and lost 10 hp");
                                player.TakeDamage(10);
                                stats.RecordDamageTaken(10);
                            }
                            else if (map.CurrentRoom.Description.ToLower().Contains("riddle"))
                            {
                                Console.WriteLine("Puzzle Room Challenge: What has keys but can't open locks?");
                                Console.Write("Your answer: ");
                                string answer = Console.ReadLine();
                                if (answer.ToLower().Contains("piano"))
                                {
                                    Console.WriteLine("Correct! You can proceed");
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect! The floor shakes but you barely can stand on");
                                    player.TakeDamage(5);
                                    stats.RecordDamageTaken(5);
                                }
                            }
                        }
                        break;

                    case "5":
                        // fight any monster in the room
                        Combat();
                        break;

                    case "6":
                        // show what's in your inventory
                        Console.WriteLine("Inventory: " + player.InventoryContents());
                        break;

                    case "7":
                        // end the game and show your stats
                        playing = false;
                        stats.PrintSummary();
                        Console.WriteLine($"Game log saved at: {Path.GetFullPath("game_log.txt")}");
                        break;

                    case "8":
                        // save the game
                        stats.Save(player);
                        Console.WriteLine("Game saved successfully.");
                        break;

                    case "9":
                        // try healing (example of overloaded methods)
                        Console.Write("Enter reason for healing (or leave empty if you don't want to specify): ");
                        string reason = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(reason))
                            player.Heal();             // default healing
                        else
                            player.Heal(20, reason);   // healing with reason
                        break;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
        }

        // this is the combat logic between the player and monster
        private void Combat()
        {
            var monster = map.CurrentRoom.Monster;
            if (monster == null)
            {
                Console.WriteLine("No monsters here.");
                return;
            }

            Console.WriteLine($"A {monster.Name} appears!");

            while (player.Health > 0 && monster.Health > 0)
            {
                Console.Write("Attack (y/n)? ");
                if (Console.ReadLine().ToLower() == "y")
                {
                    Console.WriteLine("You attack!");
                    monster.TakeDamage(20);
                    stats.RecordDamageDealt(20);

                    if (monster.Health > 0)
                    {
                        monster.Attack(player);
                        stats.RecordDamageTaken(10);
                        MonsterAI.React(monster); // adds a little monster personality
                    }
                }
                else
                {
                    Console.WriteLine("You hesitate..ops monster attacks!");
                    monster.Attack(player);
                    stats.RecordDamageTaken(10);
                    MonsterAI.React(monster);
                }
            }

            if (monster.Health <= 0)
            {
                Console.WriteLine($"You defeated the {monster.Name}!");
                stats.RecordMonsterDefeat();
                map.CurrentRoom.Monster = null;
            }
            else
            {
                Console.WriteLine("You died. Game over.");
                stats.PrintSummary();
                Console.WriteLine($"Game log saved at: {Path.GetFullPath("game_log.txt")}");
                playing = false;
            }
        }
    }
}
