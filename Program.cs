using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorerTests;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Main game and where player can start the game 
              Game game = new Game();
              game.Start();
            //GameTestDebug gameTest = new GameTestDebug();
            //gameTest.RunTests();
            Console.WriteLine("Waiting for your Implementation");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
