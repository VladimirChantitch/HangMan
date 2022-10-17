using System;
using System.Collections.Generic;
using System.Text;

namespace JeuDuPendu
{
    public class GameLoop
    {
        /// <summary>
        /// the word to guess
        /// </summary>
        string word = "fromage";

        /// <summary>
        /// the player playing
        /// </summary>
        Player player;

        /// <summary>
        /// the lenght of the word to guess
        /// </summary>
        int wordLength = 0; 

        /// <summary>
        /// The word currently guessed by the player
        /// </summary>
        string pendingWord = "";

        /// <summary>
        /// the life left for the player
        /// </summary>
        int life = 6;

        /// <summary>
        /// has the player found the word to guess
        /// </summary>
        bool isWordFound = false;

        /// <summary>
        /// List of all the valid index [--small error of algo but its not a probleme for this solution--]
        /// </summary>
        List<int> validIndex = new List<int>();

        /// <summary>
        /// An action to draw the hangman
        /// </summary>
        Action draw;

        /// <summary>
        /// The object to draw the hangman in the console 
        /// </summary>
        DrawHangeg drawHangeg = new DrawHangeg();


        /// <summary>
        /// The main constructor
        /// </summary>
        /// <param name="word"> word to guess</param>
        /// <param name="player"> player playing</param>
        public GameLoop(string word, Player player)
        {
            this.word = word;
            this.player = player;
        }

        /// <summary>
        /// A fonction to start ths instance of the game
        /// </summary>
        public void Start()
        {
            drawHangeg.SetUpDrawCallBack(out draw);
            wordLength = word.Count<char>();
            PromptTheWord();
            while (life > 0 && !isWordFound)
            {
                string guess = AskForAGuess();
                if (guess != null) ProcessGuess(guess);

                if (life <= 0)
                {
                    Loose();
                }
                if (pendingWord == word)
                {
                    Win();
                }
            }  
        }

        /// <summary>
        /// When the player looses
        /// </summary>
        private void Loose()
        {
            Console.WriteLine("Well you loose this one");
            Console.WriteLine("The word was : " + word);
            Console.WriteLine();
            player.ResetScore();
        }

        /// <summary>
        /// When the player wins
        /// </summary>
        private void Win()
        {
            Console.WriteLine("well you won");
            Console.WriteLine();
            player.AddScore();
            isWordFound = true;
        }

        /// <summary>
        /// Called once to prompt some instrucition at the biggining of the game
        /// </summary>
        private void PromptTheWord()
        {
            Console.WriteLine("The secret word is " + wordLength + " long");
            Console.WriteLine("Please try to find it in less then " + life + " tries");
            Console.WriteLine();
            for (int i = 0; i < word.Count<char>(); i++)
            {
                pendingWord += "*";
            }
            Console.WriteLine(pendingWord);
            Console.WriteLine();
        }

        /// <summary>
        /// Aske the player to guess a word
        /// </summary>
        /// <returns>the current gues of the player</returns>
        private string AskForAGuess()
        {
            Console.WriteLine("You've got " + life + "lives left !!!! ");
            Console.WriteLine("Please Input a letter or the entire word");
            string guess = Console.ReadLine();
            if (guess != null) return guess;
            else return "";
        }

        /// <summary>
        /// Find out if the guess guessed by the guessing player is ok
        /// </summary>
        /// <param name="guess"> the guess of the player</param>
        private void ProcessGuess(string guess)
        {
            guess.ToLower();
            switch (guess.Count<char>()){
                case > 1:
                    AWordIsPrompt(guess);
                    break;
                case > 0:
                    ALetterIsPrompt(guess);
                    break ;
                case 0:
                    Console.WriteLine("Please write Something you dummy");
                    Console.WriteLine();
                    break;
            }
        }

        /// <summary>
        /// If a word has been prompt by the player
        /// </summary>
        /// <param name="guess">the guess of the playe</param>
        private void AWordIsPrompt(string guess)
        {
            if (guess.Count<char>() < wordLength || guess.Count<char>() > wordLength)
            {
                Console.WriteLine("Please remember the word is " + wordLength + "character long");
            }
            else
            {
                if (guess != word)
                {
                    Console.WriteLine("Nice Try !!");
                    RemoveALife();
                    return;
                }
                else
                {
                    Console.WriteLine("Well Done !! You've found the word");
                    pendingWord = guess;
                }
            }
        }

        /// <summary>
        /// if a single character has been prompt by the player
        /// </summary>
        /// <param name="guess">the guess of the playe</param>
        private void ALetterIsPrompt(string guess)
        {
            int index = 0;
            bool foundAChar = false;
            foreach (char character in word)
            {
                if (character == guess[0])
                {

                    validIndex.Add(index);
                    ReWriteWord();
                    Console.WriteLine("Congratulation you've found a letter");
                    foundAChar = true;
                }
                index++;
            }
            if (!foundAChar)
            {
                RemoveALife();
            }
        }

        /// <summary>
        /// Rewrite to pending word to make it correspond to the current advancement of the player
        /// </summary>
        private void ReWriteWord()
        {
            pendingWord = "";
            for(int i = 0; i < wordLength; i++)
            {
                if (validIndex.Contains(i))
                {
                    pendingWord += word[i];
                }
                else
                {
                    pendingWord += "*";
                }
            }
            Console.WriteLine(pendingWord);
        }

        /// <summary>
        /// Remove a life to the player and draw the next part of the hangman
        /// </summary>
        private void RemoveALife()
        {
            life--;
            draw.Invoke();
        }
    }
}
