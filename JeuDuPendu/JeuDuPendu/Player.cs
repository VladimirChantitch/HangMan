using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuPendu
{
    public class Player
    {
        /// <summary>
        /// Name of the player
        /// </summary>
        public string name { get; private set; }
        /// <summary>
        /// Current score of the player
        /// </summary>
        public int score { get; private set; }
        /// <summary>
        /// Is the player able to win without failling
        /// </summary>
        public bool serialSuccess = false;

        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        /// <summary>
        /// Increasse the score of the player
        /// </summary>
        public void AddScore()
        {
            if (serialSuccess)
            {
                score *= 2;
            }
            else
            {
                serialSuccess = true;
                score++;
            }
        }

        /// <summary>
        /// Reset The score of the player when he fails
        /// </summary>
        public void ResetScore()
        {
            score = 0;
            serialSuccess = false;
        }
    }
}
