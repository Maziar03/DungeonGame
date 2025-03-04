/* This class defines a room in the dungeon exploration game, handling its properties, interactions, and connections to other rooms.
 * attributes such as its Information, the next room, and the presence of an enemy.
 *
 * Attributes:
 * - Info(string): A private field that stores the room's Information.
 * - NextRoom (string): A property that stores the identifier of the next room.
 * - HasEnemy (bool): Indicates whether the room contains an enemy or not.
 *
 * Methods:
 * - Room(string Info, string nextRoom = null, bool hasEnemy = false):
 * - Constructor that initialises the room's information, next room, and enemy existence.
 * - GetInfo(): Returns the Info of the room.
 */

namespace DungeonExplorer
{
    public class Room
    {   // Stores the Info of the room.
        private string Info;
        // Gets the identifier of the next room connected to this one.
        public string NextRoom { get; private set; }
        // Indicates whether the room contains an enemy or not.
        public bool HasEnemy { get; set; }

        public Room(string Info, string nextRoom = null, bool hasEnemy = false)
        {
            // Initialises a new instance of the Room class with a info, an optional next room,
            // and an optional enemy presence.
            this.Info = Info;
            NextRoom = nextRoom;
            HasEnemy = hasEnemy;
        }

        public string GetInfo()
        {
            // Returns the information of the room.
            return Info;

        }
    }
}