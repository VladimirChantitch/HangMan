using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuPendu
{
    /// <summary>
    /// This class draws the hangman, its a proof of principal it can be upgraded a lot by checking the char by char rather than list by list
    /// </summary>
    public class DrawHangeg
    {
        public int fail = 0;
        List<List<string>> drawing = new List<List<string>>();

        /// <summary>
        /// Construtor sets up the drawing in some sor of data structure [improovement needed]
        /// </summary>
        public DrawHangeg()
        {
            List<string> charList_6 = new List<string>() { " ", "|", "_", "_", "_", "_", "\n" };
            List<string> charList_5 = new List<string>() { " ", "|", " ", " ", "|", " ", "\n" };
            List<string> charList_4 = new List<string>() { " ", "|", " ", " ", "o", " ", "\n" };
            List<string> charList_3 = new List<string>() { " ", "|", " ", "/", "|", @"\", "\n" };
            List<string> charList_2 = new List<string>() { " ", "|", " ", "/", " ", @"\", "\n" };
            List<string> charList_1 = new List<string>() { "_", "|", "_", " ", " ", " ", "\n" };

            drawing.Add(charList_6);
            drawing.Add(charList_5);
            drawing.Add(charList_4);
            drawing.Add(charList_3);
            drawing.Add(charList_2);
            drawing.Add(charList_1);
        }

        /// <summary>
        /// Draws the HangMan depending on the status of failure of the player
        /// Private to make sure not every one can cces it 
        /// </summary>
        private void Draw()
        {
            fail++;
            for (int i = 0; i < fail; i++)
            {
                drawing[i].ForEach(line => Console.Write(line));
            }
        }

        /// <summary>
        /// To set up an action to be able to access the Draw fonction
        /// </summary>
        /// <param name="draw">action to draw</param>
        public void SetUpDrawCallBack(out Action draw)
        {
            draw = null;
            draw += Draw;
        }
    }
}
