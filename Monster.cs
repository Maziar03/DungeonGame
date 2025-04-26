using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /*
    * Description:
    * This class represents any basic monster in the game .
    * It inherits from the abstract Creature class, so it has health and a name.
    * It also has an attack method that can be customized by subclasses like Goblin or Dragon.
    
    * Main Functionality:
    * - Sets the monster’s name and health
    * - Has a default attack, but subclasses can change it
    
    * Input Parameters:
    * - name: what to call the monster
    * - health: how much health it starts with
    
    * Expected Output:
    * - When attacking, shows a message and damages the player
    */

    public class Monster : Creature
    {
        // basic attack — monsters hit the player for 10 damage by default
        public virtual void Attack(Player player)
        {
            Console.WriteLine($"{Name} attacks you!");
            player.TakeDamage(10);
        }

        // creates a new monster with a name and starting health
        public Monster(string name, int health) : base(name, health) { }
    }
}
