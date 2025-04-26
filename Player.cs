using System;
using System.Collections.Generic;


namespace DungeonExplorer
{
    /*
    * Description:
    * This class represents the player you control in the game.
    * It inherits from the abstract Creature class, so it already has a name and health.
    * It also handles inventory and lets the player use items and heal.
    
    * Main Functionality:
    * - Manages the player's items (using an Inventory object)
    * - Lets the player pick up and use items
    * - Heals the player when needed
    
    * Input Parameters:
    * - name: the player’s chosen name
    * - health: the amount of health the player starts with
    
    * Expected Output:
    * - Shows healing messages
    * - Inventory changes depending on actions
    */

    public class Player : Creature
    {
        // keeps track of the player’s items (like potions or weapons)
        public Inventory Inventory { get; private set; }

        // sets up the player with a name, health, and a new inventory
        public Player(string name, int health) : base(name, health)
        {
            Inventory = new Inventory();
        }

        // lets the player pick up an item and add it to inventory
        public void PickUpItem(Item item)
        {
            Inventory.AddItem(item);
        }

        // uses an item by name — stats tracking is optional
        public void UseItem(string itemName, Statistics stats = null)
        {
            Inventory.UseItem(itemName, this, stats);
        }

        // lists what’s currently in the player’s inventory
        public string InventoryContents() => Inventory.ListItems();

        // adds health to the player (used by potions or healing)
        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} heals for {amount}. Total health: {Health}");
        }
    }
}
