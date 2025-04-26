using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /*
    * Description:
    * This class is for weapons that the player can pick up and hold in their inventory.
    * Weapons are items that have a damage value, though they don’t affect battles yet.
    * This class inherits from Item, so it has to include a Use method.
    
    * Main Functionality:
    * - Stores the weapon’s name and how much damage it can deal
    * - Lets the player "use" the weapon (prints a message for now)
    
    * Expected Output:
    * - Console message when the weapon is used
    */

    public class Weapon : Item
    {
        // Shows how much damage the weapon would do (not used in battle yet)
        public int Damage { get; private set; }

        // Sets the name and damage of the weapon when it’s created
        public Weapon(string name, int damage) : base(name)
        {
            Damage = damage;
        }

        // Runs when the player uses the weapon (for now it just prints a message)
        public override void Use(Player player)
        {
            Console.WriteLine($"You swing the {Name}, but nothing happens right now.");
        }
    }
}
