using System;
using System.Collections.Generic;

/* This class represents a player in the dungeon exploration game, managing their stats, inventory, and interactions within the dungeon.
 * attributes such as name, health, and inventory.
 *
 * Attributes:
 * - Name(string): The player's name.
 * - Health (int): The player's health points.
 * - inventory (List<string>): A private list that stores the player's collected items.
 *
 * Methods:
 * - Player(string name, int health): Constructor that initialises the player with a name and health.
 * - PickUpItem(string item): Adds an item to the player's inventory and notifies them.
 * - TakeDamage(int damage): Reduces the player's health and prints the remaining health of them.
 * - InventoryContents(): Returns a string representation of the player's inventory.
 */

namespace DungeonExplorer
{
    public class Player
    {   // Gets the player's name.
        public string Name { get; private set; }
        // Gets the player's health points.
        public int Health { get; private set; }
        // Stores the player's inventory items.
        private List<string> inventory;

        public Player(string name, int health)
        {  // Initialises a new instance of the Player class with a specified name and health value.
            Name = name;
            Health = health;
            inventory = new List<string>();
        }

        public void PickUpItem(string item)
        { // Adds an item to the player's inventory.
            inventory.Add(item);
            Console.WriteLine("You picked up: " + item);

        }

        public void TakeDamage(int damage)
        {
            // Reduces the player's health by a specified damage amount and prints the health.
            Health -= damage;
            Console.WriteLine($"You have {Health} health remaining.");
        }

        public string InventoryContents()
        {   // Returns a string representation of the player's inventory contents.
            return string.Join(", ", inventory);
        }
    }
}
