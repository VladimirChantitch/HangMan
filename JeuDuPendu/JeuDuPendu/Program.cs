using JeuDuPendu;
using System;
using System.IO;
using System.Data;

namespace LeJeuDuPendue
{
    class JeuDUPendu
    {
        public static List<string> words = new List<string>();

        public static void Main()
        {
            SetWordList();
            StartGame();
        }

        public static void StartGame()
        {
            bool isStillPlaying = true;
            Player newPlayer = new Player(AskForName(), 0);
            Console.WriteLine("hi " + newPlayer.name + " welcome back!!!!!");
            //HighScore highScore = new HighScore();

            while (isStillPlaying)
            {
                ///Select Game Options
                string word = GetARandomWord();
                GameLoop gameLoop = new GameLoop(word, newPlayer);
                gameLoop.Start();
                Console.WriteLine("Your score is currently " + newPlayer.score + " well done !!!");
                isStillPlaying = AskIfWantsToContinue();
            }

            //highScore.AddANewHighScore(newPlayer);
            //highScore.SaveHighScore();
        }

        public static string AskForName()
        {
            Console.WriteLine("First what is your name ?");
            string name = Console.ReadLine();
            return name;
        }

        public static bool AskIfWantsToContinue()
        {
            Console.WriteLine("Do you wish to try again ?");
            Console.WriteLine("yes or no?");
            string statement = Console.ReadLine();
            statement.ToLower();
            switch (statement)
            {
                case "yes":
                    return true;
                case "no":
                    return false;
            }
            return false;
        }

        public static void SetWordList()
        {
            string[] file_words = new string[0];
            try
            {
                file_words = File.ReadAllLines((@"D:\\01_IPI_Cours\\cours\\.Net\\JeuDuPendu\\JeuDuPendu" + "//textFile1.txt"));

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (file_words.Length != 0)
            {
                words.AddRange(file_words.ToList<string>());
            }
            words.Add("chat");
            words.Add("chien");
            words.Add("roblochon");
        }

        public static string GetARandomWord()
        {
            Random random = new Random();
            return words[random.Next(words.Count())];
        }
    }
}
