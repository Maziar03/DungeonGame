using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /*
    * Description:
    * This class handles the player’s inventory. It keeps track of all the items
    * like potions or weapons and lets you add, use, or remove them.
    
    * Main Functionality:
    * - Add items to the inventory (up to a max limit)
    * - Use or discard items
    * - View what’s in your inventory
    * - Sort and list specific item types (like potions or strongest weapons)
    
    * Input Parameters:
    * - itemName (when using or discarding)
    * - Player and optional Statistics object (when using items)
    
    * Expected Output:
    * - Console messages when items are added, used, or removed
    * - Printed inventory lists or item effects
    */

    public class Inventory
    {
        private List<Item> items = new List<Item>();  // all the items  carrying
        private const int MaxItems = 5;               // how many items we can hold

        // add item to your inventory if there's space
        public void AddItem(Item item)
        {
            if (items.Count >= MaxItems)
            {
                Console.WriteLine("Inventory full. Consider discarding an item.");
                return;
            }
            items.Add(item);
            Console.WriteLine($"Added {item.Name} to inventory.");
        }

        // use an item by name, remove it after use, and update stats if needed
        public void UseItem(string itemName, Player player, Statistics stats = null)
        {
            var item = items.FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower());
            if (item != null)
            {
                item.Use(player);
                stats?.RecordItemUse(item.Name);
                items.Remove(item);
            }
            else
            {
                Console.WriteLine($"You don’t have \"{itemName}\" in your inventory or it’s already been used.");
            }
        }

        // remove an item from your inventory if it's there
        public void DiscardItem(string itemName)
        {
            var item = items.FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower());
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine($"Discarded {item.Name}.");
            }
            else
            {
                Console.WriteLine("That item is not in your inventory.");
            }
        }

        // shows all item names in your inventory
        public string ListItems()
        {
            return items.Count == 0 ? "Empty" : string.Join(", ", items.Select(i => i.Name));
        }

        // prints all healing potions you’re carrying
        public void ListPotions()
        {
            var potions = items.OfType<Potion>();
            Console.WriteLine("Healing Potions: " + string.Join(", ", potions.Select(p => p.Name)));
        }

        // prints all weapons sorted from strongest to weakest
        public void ListWeaponsByDamage()
        {
            var weapons = items.OfType<Weapon>().OrderByDescending(w => w.Damage);
            Console.WriteLine("Weapons (sorted by damage):");
            foreach (var weapon in weapons)
            {
                Console.WriteLine($"{weapon.Name} - Damage: {weapon.Damage}");
            }
        }

        // gets a list of all weapons (used for future logic if needed)
        public List<Weapon> GetWeapons() => items.OfType<Weapon>().ToList();
    }
}
