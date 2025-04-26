using System;
using NUnit.Framework;
using DungeonExplorer;
using System.Collections.Generic;

namespace DungeonExplorerTests
{
    /*
    * Description:
    * This class contains tests for key parts of the Dungeon Explorer game.
    * It checks if the game works as expected — from health changes to room movement.
    *
    * Main Functionality:
    * - Makes sure taking damage and healing update health correctly.
    * - Checks if inventory behaves right (items added, used, removed).
    * - Confirms monsters deal damage when they attack.
    * - Verifies the player can move between rooms properly.
    *
    * Input Parameters:
    * - No input from user — test data is created inside each test method.
    *
    * Expected Output:
    * - Test results: All tests pass if the game logic is working correctly.
    */

    [TestFixture]
    public class GameTestDebug
    {
        // checks if taking damage lowers the player’s health correctly
        [Test]
        public void PlayerReducesHealth()
        {
            Player player = new Player("TestPlayer", 100);
            player.TakeDamage(20);
            Assert.That(player.Health, Is.EqualTo(80));
        }

        // checks if healing adds to player’s health
        [Test]
        public void PlayerIncreasesHealth()
        {
            Player player = new Player("TestPlayer", 50);
            player.Heal(25);
            Assert.That(player.Health, Is.EqualTo(75));
        }

        // adds a potion, uses it, and checks if it heals and disappears from inventory
        [Test]
        public void InventoryAddsAndUsesPotion()
        {
            Player player = new Player("TestPlayer", 50);
            Potion potion = new Potion("Small Heal", 20);
            player.PickUpItem(potion);

            Assert.That(player.InventoryContents(), Is.EqualTo("Small Heal"));
            player.UseItem("Small Heal");
            Assert.That(player.InventoryContents(), Is.EqualTo("Empty"));
            Assert.That(player.Health, Is.EqualTo(70));
        }

        // checks if monster attack causes player to lose health
        [Test]
        public void MonsterAttackPlayer()
        {
            Player player = new Player("Hero", 100);
            Monster goblin = new Goblin();
            goblin.Attack(player);
            Assert.That(player.Health, Is.EqualTo(92));
        }

        // tests if player moves from Entrance to Hallway (if there's no monster blocking)
        [Test]
        public void ovesThroughRooms()
        {
            {
                GameMap map = new GameMap();
                Assert.That(GetRoomName(map.CurrentRoom), Is.EqualTo("Entrance"));

                map.CurrentRoom.Monster = null; // correctly remove monster from CurrentRoom
                map.MoveToNextRoom();
                Assert.That(GetRoomName(map.CurrentRoom), Is.EqualTo("Hallway"));
            }
        }

        // figures out which room the player is in based on text in the room description
        private string GetRoomName(Room room)
        {
            string description = room.Description.ToLower();

            if (description.Contains("entrance")) return "Entrance";
            if (description.Contains("corridor")) return "Hallway";
            if (description.Contains("gold glimmers")) return "Treasure Room";
            if (description.Contains("golden hoard")) return "VictoryRoom";
            return "Unknown";


        }
    }
}
