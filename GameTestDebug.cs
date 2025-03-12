using NUnit.Framework;
using DungeonExplorer;
using System;

namespace DungeonExplorerTests
{
    [TestFixture]
    public class GameTestDebug
    {
        public void RunTests()
        {
            Console.WriteLine("Running Game Tests...\n");

            PlayerNormalHealth();
            PlayerHealthReduce();
            PlayerCanPickUpItem();
            RoomStoresCorrectInfo();

            Console.WriteLine("\nAll tests passed !");
        }
        [Test]
        public void PlayerNormalHealth()
        {
            Player player = new Player("TestPlayer", 100);
            Assert.That(player.Health, Is.EqualTo(100), "Players health is 100.");
        }

        [Test]
        public void PlayerHealthReduce()
        {
            Player player = new Player("TestPlayer", 100);
            player.TakeDamage(20);
            Assert.That(player.Health, Is.EqualTo(80), "Health is decreasing by 20 ");
        }

        [Test]
        public void PlayerCanPickUpItem()
        {
            Player player = new Player("TestPlayer", 100);
            player.PickUpItem("Axe");
            Assert.That(player.InventoryContents(), Is.EqualTo("Axe"), "Player picked up a Axe.");
        }

        [Test]
        public void RoomStoresCorrectInfo()
        {
            Room room = new Room("Dark Dungeon", "Treasure Room", false);
            Assert.That(room.GetInfo(), Is.EqualTo("Dark Dungeon"), "Room info should match.");
            Assert.That(room.NextRoom, Is.EqualTo("Treasure Room"), "Room is leading to 'Treasure Room'.");
        }
    }
}
