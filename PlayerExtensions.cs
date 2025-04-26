using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /*
    * Description:
    * This static class adds extra methods to the Player class without changing it directly.
    * It shows static polymorphism (method overloading) by giving two ways to heal the player.
    
    * Main Functionality:
    * - Lets the player heal without needing to say why
    * - Or lets them heal and give a reason (like after a fight)
    
    * Input Parameters:
    * - amount (optional): how much to heal
    * - reason (optional): message showing why the player healed
    
    * Expected Output:
    * - Player’s health goes up
    * - Console message appears if a reason is provided
    */

    public static class PlayerExtensions
    {
        // heals the player by 10 — no reason needed
        public static void Heal(this Player player)
        {
            player.Heal(10);
        }

        // heals the player by a set amount and shows a reason why
        public static void Heal(this Player player, int amount, string reason)
        {
            player.Heal(amount);
            Console.WriteLine($"Reason for healing: {reason}");
        }
    }
}
