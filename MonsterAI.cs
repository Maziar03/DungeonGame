using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /*
    * Description:
    * This is a static class that helps make monsters feel a bit smarter in battle.
    * It checks how much health the monster has and makes them react in different ways.
    
    * Main Functionality:
    * - Adds basic AI behavior based on monster health
    * - Makes combat feel more dynamic and less predictable
    
    * Input Parameters:
    * - monster: the monster that’s currently fighting
    
    * Expected Output:
    * - Prints different messages depending on how weak the monster is
    */

    public static class MonsterAI
    {
        // reacts based on how hurt the monster is — scared if weak, aggressive if strong
        public static void React(Monster monster)
        {
            if (monster.Health < 20)
            {
                Console.WriteLine($"{monster.Name} looks frightened and tries to retreat!");
            }
            else
            {
                Console.WriteLine($"{monster.Name} prepares a counterattack.");
            }
        }
    }
}
