using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Security.Cryptography;

/* This class represents the main game logic for the Dungeon Explorer game.
 * It manages player interactions, room navigation, combat , and game flow.
 * Attributes:
 * - player(Player): Represents the player character in the game.
 * - rooms (Dictionary<string, Room>): Stores all rooms available in the game.
 * - currentRoom (Room): Tracks the room the player is currently in.
 * - playing (bool): Indicates whether the game is currently active or not.
 * Methods:
 * - Game(): Constructor that initialises the player and the dungeon layout.
 * - Start(): Begins the game loop and manages user input.
 * - HandleChoice(string choice): Handles the player's menu selections.
 * - MoveToNextRoom(): Moves the player to the next room if possible.
 * - StartCombat(): Engages the player in combat with an enemy if present.
 */

namespace DungeonExplorer
{
    internal class Game
    {
        // Shows the player in the game.
        private Player player;
        // Stores the game's rooms using a dictionary.
        private Dictionary<string, Room> rooms;
        // Shows the current room the player is in.
        private Room currentRoom;
        // Indicates whether the game is currently running.
        private bool playing;

        public Game()
        {
            // Initialises the game, creating a player and setting up the dungeon layout.
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName, 100);

            rooms = new Dictionary<string, Room>
            {
                { "Entrance", new Room("A dark and creepy hallway where a single torch flickers, making eerie shadows dance on the damp stone walls.") },
                { "Hallway", new Room("A long, damp hallway stretches ahead. You can hear a faint sound in the distance—something’s up.") },
                { "Treasure Room", new Room("A shiny treasure room stacked with gold—but there’s a monster keeping watch!", null, true) }
            };

            currentRoom = rooms["Entrance"];
            Console.WriteLine($"\nWelcome, {player.Name}! You enter the dungeon!!!");
        }

        public void Start()
        {
            // Starts the game loop and handles user engagement
            playing = true;
            while (playing)
            {
                Console.WriteLine("\n***Chose one of these options***");
                Console.WriteLine("1. View Room Info");
                Console.WriteLine("2. Pick Up an Item");
                Console.WriteLine("3. Check Status");
                Console.WriteLine("4. Move to Next Room");
                Console.WriteLine("5. Fight Monster");
                Console.WriteLine("6. Exit Game");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                HandleChoice(choice);
            }
        }

        private void HandleChoice(string choice)
        {
            // Execute the player's menu selection and executes the corresponding action.
            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nRoom Info: " + currentRoom.GetInfo());
                    break;
                case "2":
                    Console.Write("Enter item to pick up: ");
                    string item = Console.ReadLine();
                    player.PickUpItem(item);
                    break;
                case "3":
                    Console.WriteLine("\nPlayer Status:");
                    Console.WriteLine("Name: " + player.Name);
                    Console.WriteLine("Health: " + player.Health);
                    Console.WriteLine("Inventory: " + (player.InventoryContents() == "" ? "Empty" : player.InventoryContents()));
                    break;
                case "4":
                    MoveToNextRoom();
                    break;
                case "5":
                    if (currentRoom.HasEnemy)
                        StartCombat();
                    else
                        Console.WriteLine("\nNo monsters in sight!");
                    break;
                case "6":
                    Console.WriteLine("\nExiting the game. BYE BYE!");
                    playing = false;
                    break;
                default:
                    Console.WriteLine("Oops! That’s not a valid choice. Try again!");
                    break;
            }
        }

        private void MoveToNextRoom()
        {
            // Moves the player to the next room if possible.
            if (currentRoom.HasEnemy)
            {
                Console.WriteLine("\n A monster stands in your way! You’ll have to take it down first.");
                return;
            }

            if (string.IsNullOrEmpty(currentRoom.NextRoom))
            {
                Console.WriteLine("\nThere's no way out. You've reached the dungeon's final chamber!");
                return;
            }

            if (rooms.ContainsKey(currentRoom.NextRoom))
            {
                currentRoom = rooms[currentRoom.NextRoom];
                Console.WriteLine("\nYou step into the next room. What awaits you?");
            }
        }

        private void StartCombat()
        {
            // Starts combat with an enemy in the room.
            Console.WriteLine("\nWhoa! A monster just showed up! Get ready to fight!");
            int monsterHealth = 50;

            while (player.Health > 0 && monsterHealth > 0)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Attack");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("You land a powerful hit! The monster takes 20 damage.");
                    monsterHealth -= 20;

                    if (monsterHealth > 0)
                    {
                        Console.WriteLine("The monster attacks back! You take 10 damage.");
                        player.TakeDamage(10);
                    }
                }
                else
                {
                    Console.WriteLine("That's not an option! You have no choice but to fight!");
                }
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("\nYou fought bravely, but you die. Game over.");
                playing = false;
            }
            else if (monsterHealth <= 0)
            {
                Console.WriteLine("\nYou’ve defeated the monster! The way forward is now open.");
                currentRoom.HasEnemy = false;
            }
        }
    }
}
