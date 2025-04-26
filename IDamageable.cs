using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /*
    * Description:
    * This interface is for anything in the game that can take damage,
    * like players or monsters.
    
    * Main Functionality:
    * - It Makes sure every class that uses this has a TakeDamage method.
    * - This keeps damage logic consistent across different parts of the game.
    
    * Input Parameters:
    * - damage: how much health should be taken away
    
    * Expected Output:
    * - Health is reduced, and usually a message shows the result
    */

    public interface IDamageable
    {
        // Its for any class that gets hit must handle this method
        void TakeDamage(int damage);
    }
}
