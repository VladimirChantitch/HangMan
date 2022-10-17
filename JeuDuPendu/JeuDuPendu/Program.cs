using JeuDuPendu;
using System;
using System.IO;
using System.Data;

namespace LeJeuDuPendue
{
    /// <summary>
    /// Main class of the Hangman Game
    /// </summary>
    class JeuDUPendu
    {
        /// <summary>
        /// List of the words in the game
        /// </summary>
        public static List<string> words = new List<string>();

        public static void Main()
        {
            SetWordList();
            StartGame();
        }

        /// <summary>
        /// Start the game should only be called once
        /// </summary>
        public static void StartGame()
        {
            bool isStillPlaying = true;
            Player newPlayer = new Player(AskForName(), 0);
            Console.WriteLine("hi " + newPlayer.name + " welcome back!!!!!");
            HighScore highScore = new HighScore();

            while (isStillPlaying)
            {
                string word = GetARandomWord();
                GameLoop gameLoop = new GameLoop(word, newPlayer);
                gameLoop.Start();
                Console.WriteLine("Your score is currently " + newPlayer.score + " well done !!!");
                isStillPlaying = AskIfWantsToContinue();
            }

            highScore.AddANewHighScore(newPlayer);
            highScore.SaveHighScore();
        }

        /// <summary>
        /// A fonction to ask the player to prompt his name
        /// </summary>
        /// <returns>the name of the player</returns>
        public static string AskForName()
        {
            Console.WriteLine("First what is your name ?");
            string name = Console.ReadLine();
            return name;
        }

        /// <summary>
        /// A Fonction to ask if the player wants to continue play the game after a fail or a success
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// A fonction to init the words used for the game 
        /// </summary>
        public static void SetWordList()
        {
            string[] file_words = new string[0];
            try
            {
                file_words = File.ReadAllLines((@"D:\01_IPI_Cours\Git\HangMan\JeuDuPendu\JeuDuPendu" + "//textFile1.txt"));

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

        /// <summary>
        /// A fonction to get a random word
        /// </summary>
        /// <returns>A random word from the list</returns>
        public static string GetARandomWord()
        {
            Random random = new Random();
            return words[random.Next(words.Count())];
        }
    }
}
