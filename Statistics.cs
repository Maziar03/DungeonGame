using System;
using System.IO;

namespace DungeonExplorer
{
    /*
    * Description:
    * This class keeps track of how the player is doing in the game.
    * It counts things like score, damage, how many monsters you beat, and logs events.
    * It also lets you save and load your game so you can continue later.
    
    * Main Functionality:
    * - Tracks all your game stats (score, damage, items used, etc.)
    * - Lets you save your progress to a file
    * - Lets you load your last saved game
    * - Writes logs to an external file to keep a record of key events
    
    * Input Parameters:
    * - player object (for saving health and name)
    
    * Expected Output:
    * - Text summary of stats
    * - Game save and load files
    * - Log file with key actions
    */

    public class Statistics
    {
        public int MonstersDefeated { get; private set; }
        public int ItemsUsed { get; private set; }
        public int DamageTaken { get; private set; }
        public int DamageDealt { get; private set; }
        public int Score { get; private set; }

        private readonly string logFilePath = "game_log.txt";     // where log messages go
        private readonly string saveFilePath = "savegame.txt";    // where save game data goes

        // called when you beat a monster — adds to your score and logs it
        public void RecordMonsterDefeat()
        {
            MonstersDefeated++;
            AddScore(50);
            Log("Monster defeated");
        }

        // called when you use an item — updates count and logs it
        public void RecordItemUse(string itemName)
        {
            ItemsUsed++;
            Log($"Item used: {itemName}");
        }

        // adds to damage taken, drops score, and logs the hit
        public void RecordDamageTaken(int amount)
        {
            DamageTaken += amount;
            AddScore(-amount / 2);
            Log($"Player took {amount} damage");
        }

        // adds to damage you dealt and increases score
        public void RecordDamageDealt(int amount)
        {
            DamageDealt += amount;
            AddScore(amount);
            Log($"Player dealt {amount} damage");
        }

        // updates the score and logs the change
        public void AddScore(int amount)
        {
            Score += amount;
            Log($"Score changed by {amount}, total: {Score}");
        }

        // shows everything that’s been tracked during the game
        public void PrintSummary()
        {
            Console.WriteLine("\n--- Game Statistics ---");
            Console.WriteLine($"Score: {Score}");
            Console.WriteLine($"Monsters Defeated: {MonstersDefeated}");
            Console.WriteLine($"Items Used: {ItemsUsed}");
            Console.WriteLine($"Total Damage Taken: {DamageTaken}");
            Console.WriteLine($"Total Damage Dealt: {DamageDealt}");
        }

        // saves all stats and player info to a file
        public void Save(Player player)
        {
            using (StreamWriter writer = new StreamWriter(saveFilePath))
            {
                writer.WriteLine(player.Name);
                writer.WriteLine(player.Health);
                writer.WriteLine(MonstersDefeated);
                writer.WriteLine(ItemsUsed);
                writer.WriteLine(DamageTaken);
                writer.WriteLine(DamageDealt);
                writer.WriteLine(Score);
            }
            Console.WriteLine($"Game saved to: {Path.GetFullPath(saveFilePath)}");
        }

        // loads stats and player info from a file, if one exists
        public static Statistics Load(out string playerName, out int playerHealth)
        {
            Statistics stats = new Statistics();

            if (!File.Exists("savegame.txt"))
            {
                Console.WriteLine("No saved game found.");
                playerName = "";
                playerHealth = 100;
                return stats;
            }

            string[] lines = File.ReadAllLines("savegame.txt");
            if (lines.Length < 7)
            {
                Console.WriteLine("Saved data is corrupted.");
                playerName = "";
                playerHealth = 100;
                return stats;
            }

            playerName = lines[0];
            playerHealth = int.Parse(lines[1]);
            stats.MonstersDefeated = int.Parse(lines[2]);
            stats.ItemsUsed = int.Parse(lines[3]);
            stats.DamageTaken = int.Parse(lines[4]);
            stats.DamageDealt = int.Parse(lines[5]);
            stats.Score = int.Parse(lines[6]);

            Console.WriteLine("Game loaded successfully.");
            return stats;
        }

        // writes a message into the game log with a time stamp
        private void Log(string message)
        {
            File.AppendAllText(logFilePath, $"[{DateTime.Now}] {message}\n");
        }
    }
}
