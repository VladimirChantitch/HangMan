using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuPendu
{
    public class DrawHangeg
    {
        public int fail = 0;
        List<List<string>> drawing = new List<List<string>>();

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

        public void Draw()
        {
            fail++;
            for (int i = 0; i < fail; i++)
            {
                drawing[i].ForEach(line => Console.Write(line));
            }
        }
    }
}
