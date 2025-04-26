using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /*
    * Description:
    * This is an abstract class for anything alive in the game, like players or monsters.
    * Abstract means you can’t make a Creature directly — it’s just a base to build others on.
    
    * Main Functionality:
    * - Stores name and health for all creatures.
    * - Lets creatures take damage and lose health.
    * - Other classes like Player and Monster use this as a starting point (they inherit from it).
    * - It also uses the IDamageable interface, which means 
    *   anything that inherits from this class has to be able to take damage.
    
    * Input Parameters:
    * - name: the name of the creature
    * - health: how much health it starts with
    
    * Expected Output:
    * - Message showing how much damage the creature took
    * - Updated health value after taking damage
    */

    public abstract class Creature : IDamageable
    {
        // the name of the creature, like "Goblin" or "Player"
        public string Name { get; protected set; }

        // how much health it has
        public int Health { get; protected set; }

        // sets name and health when the creature is created
        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        // reduces health when the creature takes damage
        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} takes {damage} damage. Remaining health: {Health}");
        }
    }
}
