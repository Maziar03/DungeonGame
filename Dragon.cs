using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    * Description:
    * This is a specific type of monster in the game — the Dragon.
    * It’s a strong enemy with more health and a powerful attack.
    
    * Main Functionality:
    * - Inherits from the Monster class.
    * - Has a custom attack that deals more damage than regular monsters.
    
    * Input Parameters:
    * - none (values like name and health are set inside the class)
    
    * Expected Output:
    * - Shows a message when the dragon attacks
    * - Player loses 20 health when hit
    */

public class Dragon : Monster
{
    // sets the dragon’s name and starting health using the base class
    public Dragon() : base("Dragon", 100) { }

    // dragon uses a special fire attack that hits harder than others
    public override void Attack(Player player)
    {
        Console.WriteLine("Dragon breathes fire!");
        player.TakeDamage(20);
    }
}
