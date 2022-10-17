using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuPendu
{
    public class Player
    {
        public string name { get; private set; }
        public int score { get; private set; }
        public bool serialSuccess = false;

        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

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

        public void ResetScore()
        {
            score = 0;
            serialSuccess = false;
        }
    }
}
