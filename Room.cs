using System.Collections.Generic;

namespace DungeonExplorer
{
    /*
    * Description:
    * This class represents one room in the dungeon.
    * Each room can have a description, a monster, some items, a trap,
    * and a link to the next room. It helps build the layout of the dungeon.
    
    * Main Functionality:
    * - Holds details about the room’s content (like monsters or loot)
    * - Keeps track of what room comes next
    * - Can describe itself with extra warning if something dangerous is inside
    
    * Input Parameters:
    * - description: short text about what the room looks like
    * - nextRoom: the ID or name of the next connected room 
    * - monster: a monster that might be waiting here 
    * - items: any loot or potions you can pick up 
    
    * Expected Output:
    * - When called, the room can describe itself
    * - If there’s a monster, it adds a warning to the description
    */

    public class Room
    {
        // what the room looks or feels like (text)
        public string Description { get; private set; }

        // the name of the next room — helps move the player forward
        public string NextRoom { get; private set; }

        // the monster in this room (if there is one)
        public Monster Monster { get; set; }

        // true if there's a trap — used for damage or surprises
        public bool HasTrap { get; set; }

        // items you can pick up from the floor in this room
        public List<Item> Items { get; private set; }

        // builds the room with all the info it needs (some parts optional)
        public Room(string description, string nextRoom = null, Monster monster = null, List<Item> items = null)
        {
            Description = description;
            NextRoom = nextRoom;
            Monster = monster;
            Items = items ?? new List<Item>();
        }

        // gives the description of the room and warns if there's a monster
        public string GetInfo()
        {
            return Description + (Monster != null ? " There's something moving here..." : "");
        }
    }
}
