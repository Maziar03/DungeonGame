using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /*
    * Description:
    * This class represents a healing item the player can use to restore health.
    * It inherits from the abstract Item class and defines what happens when it’s used.
    
    * Main Functionality:
    * - Stores how much health the potion restores
    * - Heals the player and shows a message when used
    
    * Input Parameters:
    * - name: the name of the potion (like "Healing Potion")
    * - healAmount: how much health it gives back
    
    * Expected Output:
    * - Player gets health back
    * - Message shows how much was healed
    */

    public class Potion : Item
    {
        // how much health this potion gives back
        public int HealAmount { get; private set; }

        // sets up the potion with a name and how much it heals
        public Potion(string name, int healAmount) : base(name)
        {
            HealAmount = healAmount;
        }

        // when the player uses it, restore their health and show a message
        public override void Use(Player player)
        {
            player.Heal(HealAmount);
            Console.WriteLine($"You drink the {Name}. You heal for {HealAmount} points.");
        }
    }
}
