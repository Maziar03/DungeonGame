using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /*
    * Description:
    * This class builds and manages the map of the dungeon — all the rooms, their order,
    * and what's inside them (monsters, items, traps).
    
    * Main Functionality:
    * - Sets up each room with a name, description, and what's inside.
    * - Adds randomness to make sure each playthrough feels a little different.
    * - Keeps track of the current room and lets the player move forward if allowed.
    
    * Input Parameters:
    * - none directly — the layout is built inside the constructor using randomness logic.
    
    * Expected Output:
    * - On calling MoveToNextRoom, updates which room the player is in.
    * - Blocks movement if there’s still a monster in the current room.
    * - Prints win message when the last room is reached.
    */

    public class GameMap
    {
        private Dictionary<string, Room> rooms = new Dictionary<string, Room>();  // all rooms in the dungeon
        public Room CurrentRoom { get; private set; }  // where the player currently is

        // builds the dungeon layout and randomly fills some rooms with monsters/items
        public GameMap()
        {
            Random rand = new Random();

            rooms["Entrance"] = new Room("You see a lit torch by the door", "Hallway", null,
                new List<Item> { new Potion("Healing Potion", 30) })
            {
                HasTrap = false
            };

            rooms["Hallway"] = new Room("A damp corridor with distant growls.", "PuzzleRoom",
                rand.Next(2) == 0 ? new Goblin() : null,
                rand.Next(2) == 0 ? new List<Item> { new Weapon("Sword", 25) } : new List<Item>())
            {
                HasTrap = true
            };

            rooms["PuzzleRoom"] = new Room("This is a riddle chamber. Solve the riddle to unlock your path.", "Armory")
            {
                HasTrap = false
            };

            rooms["Armory"] = new Room("You enter an old armory filled with epic  weapons.", "Library",
                null,
                rand.Next(2) == 0 ? new List<Item> { new Weapon("Axe", 35), new Potion("Stamina Brew", 20) } : new List<Item>())
            {
                HasTrap = false
            };

            rooms["Library"] = new Room("Ancient books whisper secrets. A trap might be hidden here.", "TreasureRoom",
                rand.Next(2) == 0 ? new Goblin() : null)
            {
                HasTrap = true
            };

            rooms["TreasureRoom"] = new Room("Gold is here—but so does danger.", "VictoryRoom", new Dragon())
            {
                HasTrap = false
            };

            rooms["VictoryRoom"] = new Room("You find a golden Box  with no threats left. You've won the game!")
            {
                HasTrap = false
            };

            // set starting point
            CurrentRoom = rooms["Entrance"];
        }

        // lets player move to the next room if there’s no monster in the way
        public bool MoveToNextRoom()
        {
            if (CurrentRoom.Monster != null)
            {
                Console.WriteLine("Defeat the monster before moving on!");
                return false;
            }

            if (string.IsNullOrEmpty(CurrentRoom.NextRoom))
            {
                Console.WriteLine("You've reached the final room.");
                return false;
            }

            CurrentRoom = rooms[CurrentRoom.NextRoom];

            // if we're in the last room with no monster, show win message
            if (CurrentRoom.NextRoom == null && CurrentRoom.Monster == null)
            {
                Console.WriteLine("You step into the golden vault and claim your treasure. You win!");
            }

            return true;
        }
    }
}
