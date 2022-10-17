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
    /// <summary>
    /// Work in progreess
    /// </summary>
    public class HighScore
    {
        Dictionary<string, int> highScore_list = new Dictionary<string, int>();

        public HighScore()
        {
            HighScoreLoad();
            HighScoreShow();
        }

        public void HighScoreShow()
        {
            Console.WriteLine("High Score");
            for (int i  = 0; i < highScore_list.Count; i++)
            {
                Console.WriteLine(highScore_list.ElementAt(i));
            }
        }
        /// <summary>
        /// Work in progress
        /// </summary>
        public void HighScoreLoad()
        {
            try
            {
                highScore_list = JsonSerializer.Deserialize<Dictionary<string, int>>(Directory.GetCurrentDirectory() + "//SaveFile.json");
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        public void AddANewHighScore(Player player)
        {
            highScore_list.Add(player.name, player.score);
        }

        public void SaveHighScore()
        {
            string json_string = JsonSerializer.Serialize(highScore_list);
            File.WriteAllText("SaveFile.json", json_string);
            Console.WriteLine(json_string);
        }
    }
}
