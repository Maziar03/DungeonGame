using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /*
    * Description:
    * This class represents a weaker type of monster in the game — the Goblin.
    * It inherits from the Monster class and changes how it attacks the player.
    
    * Main Functionality:
    * - Sets up the Goblin with a name and health.
    * - Overrides the base attack to deal light damage with a dagger.
    
    * Input Parameters:
    * - none (the Goblin’s name and health are set inside the constructor)
    
    * Expected Output:
    * - Message showing how the Goblin attacks
    * - Player loses 8 health when attacked
    */

    public class Goblin : Monster
    {
        // sets the Goblin's name and starting health using the base class
        public Goblin() : base("Goblin", 65) { }

        // Goblin attacks by slashing and deals small damage
        public override void Attack(Player player)
        {
            Console.WriteLine("Goblin slashes you with its dagger!");
            player.TakeDamage(8);
        }
    }
}
