using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JeuDuPendu
{
    public class HighScore
    {
        Dictionary<string, int> highScore_list = new Dictionary<string, int>();

        public HighScore()
        {
            HighScoreLoad();
            HighScoreShow();
        }

        /// <summary>
        /// Show the high scor panel
        /// </summary>
        public void HighScoreShow()
        {
            Console.WriteLine();
            Console.WriteLine("High Score");
            for (int i  = 0; i < highScore_list.Count; i++)
            {
                Console.WriteLine(highScore_list.ElementAt(i));
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Load the high score file
        /// </summary>
        public void HighScoreLoad()
        {
            try
            {
                string json_string = File.ReadAllText(Directory.GetCurrentDirectory() + "//SaveFile.json");
                highScore_list = JsonSerializer.Deserialize<Dictionary<string, int>>(json_string);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        /// <summary>
        /// Add a new high score profile
        /// </summary>
        /// <param name="player"> the player ou want to add</param>
        public void AddANewHighScore(Player player)
        {
            highScore_list.Add(player.name, player.score);
        }

        /// <summary>
        /// Save the current high score
        /// </summary>
        public void SaveHighScore()
        {
            string json_string = JsonSerializer.Serialize(highScore_list);
            File.WriteAllText("SaveFile.json", json_string);
            Console.WriteLine(json_string);
        }
    }
}
