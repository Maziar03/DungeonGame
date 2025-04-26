using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /*
    * Description:
    * This is an interface used for items the player can use in the game.
    * Any item that can be picked up and activated (like potions or weapons) must use this.
    
    * Main Functionality:
    * - Makes sure any class that uses this interface has a Use method.
    * - This lets the player interact with the item in the same way, no matter what type it is.
    
    * Input Parameters:
    * - player: the one using the item
    
    * Expected Output:
    * - The item does something to the player (like healing or giving feedback).
    */

    public interface ICollectible
    {
        // every item that can be used must say what happens when it’s used by the player
        void Use(Player player);
    }
}
