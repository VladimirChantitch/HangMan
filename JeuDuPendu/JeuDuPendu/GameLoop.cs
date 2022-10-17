using System;
using System.Collections.Generic;
using System.Text;

namespace JeuDuPendu
{
    public class GameLoop
    {
        string word = "fromage";
        Player player;
        int wordLength = 0; 
        string pendingWord = "";
        int life = 6;
        bool isWordFound = false;
        List<int> validIndex = new List<int>();
        DrawHangeg draw = new DrawHangeg();

        public GameLoop(string word, Player player)
        {
            this.word = word;
            this.player = player;
        }

        public void Start()
        {
            wordLength = word.Count<char>();
            PromptTheWord();
            while (life > 0 && !isWordFound)
            {
                AskForInputALetterOrAString();
                if (life <= 0)
                {
                    Console.WriteLine("Well you loose this one");
                    Console.WriteLine("The word was : " + word);
                    Console.WriteLine();
                    player.ResetScore();
                }
                if (pendingWord == word)
                {
                    Console.WriteLine("well you won");
                    Console.WriteLine();
                    player.AddScore();
                    isWordFound = true;
                }
            }  
        }

        private void PromptTheWord()
        {
            Console.WriteLine("The secret word is " + wordLength + " long");
            Console.WriteLine("Please try to find it in less then " + life + " tries");
            for (int i = 0; i < word.Count<char>(); i++)
            {
                pendingWord += "*";
            }
            Console.WriteLine(pendingWord);
            Console.WriteLine();
        }

        private void AskForInputALetterOrAString()
        {
            Console.WriteLine("You've got " + life + "lives left !!!! ");
            Console.WriteLine("Please Input a letter or the entire word");

            string guess = Console.ReadLine();
            guess.ToLower();

            if (guess.Count<char>() > 1){
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
            else if (guess.Count<char>() > 0)
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
            else
            {
                Console.WriteLine("Please write Something you dummy");
            }
        }

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

        private void RemoveALife()
        {
            life--;
            draw.Draw();
        }
    }
}
