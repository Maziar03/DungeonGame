using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /*
    * Description:
    * This is an abstract class for all items the player can collect.
    * It also uses the ICollectible interface, which means every item that inherits from this
    * must have a Use method that works on the player.
    
    * Main Functionality:
    * Stores the name of the item
    * Forces all subclasses (like Potion or Weapon) to define what happens when the item is used
    
    * Input Parameters:
    * name (for the item’s name when it's created)
    
    * Expected Output:
    * The effect of the item will depend on what the subclass does in its Use method
    */

    public abstract class Item : ICollectible
    {
        // the name of the item (e.g., "Potion", "Sword")
        public string Name { get; protected set; }

        // sets the item’s name when it's created
        public Item(string name)
        {
            Name = name;
        }

        // each specific item must say what happens when the player uses it
        public abstract void Use(Player player);
    }
}
