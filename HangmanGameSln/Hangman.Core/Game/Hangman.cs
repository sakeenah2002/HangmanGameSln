using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private string hangmanWords;
       // private string choose;
        private string _yourguesswords;
        private string _progress;
       
        private int bodyparts;
        private string[] _wordArray = { "twenty", "random", "education", "population", "champagne", "breakfast", "chocolate", "landscape", "ritual", "professional", "lesson", "cruel", "crime", "prisoner", "shareholder", " pyramid", " vampire", "werewolf", "mermaid", "demigod", "queen", "reign", "fairy", " bisexual", "asexual", "lesbian", "transgender" };


        public HangmanGame()
        {
            _renderer = new GallowsRenderer();

            Random random = new Random();
            int randomNo = random.Next(0, _wordArray.Length);
            hangmanWords = _wordArray[randomNo];

            _yourguesswords = hangmanWords;
            for (int x = 0; x < hangmanWords.Length; x++)
            {
                _progress += "-";
            }

        }

        public string Getprogress()
        {
            return _progress;
        }
      
       


        public void Run()
        {
             void progressArray(char letter)
            {
                char[] progressArray = _progress.ToCharArray();

                for (int i = 0; i < _yourguesswords.Length; i++)
                {
                    if (_yourguesswords[i] == letter)
                    {
                        progressArray[i] = letter;
                    }

                }
                _progress = new string(progressArray);
            }

            bodyparts = 6;

            bool play = true;
            
            while (play)
            {
                _renderer.Render(5, 5, bodyparts);

                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("CLUE ! word amount " + _progress.Length);              
                Console.Write("Amount of letters in the word : ");
                Console.WriteLine(Getprogress());
                Console.SetCursorPosition(0, 15);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("What is your next guess: ");
                string nextGuess = Console.ReadLine();
                Console.WriteLine(_progress);

                progressArray(nextGuess[0]);

                       
                if (bodyparts == 0)

                while (true)
                {
                    Console.WriteLine("Please enter next guess:");
                    string nextguess = Console.ReadLine();


                    Console.WriteLine(_progress);
                }
                for (int i = 0; i < _yourguesswords.Length; i++)
                {

                    if (_yourguesswords.Contains(nextGuess))
                    {

                    }
                    else if (!_yourguesswords.Contains(nextGuess))
                    {
                        bodyparts--;

                        break;
                    }

                }
                if (_progress == _yourguesswords)
                {
                    Console.SetCursorPosition(0, 18);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"You Win! The word was {_yourguesswords}. congrates nice one :)");
                    play = false;
                }
                if (bodyparts == 0)
                {
                    _renderer.Render(5, 5, 0);
                    Console.SetCursorPosition(0, 18);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You Lose! The word was {_yourguesswords}, better luck next time :(");
                    play = false;
                }

            }
               
                                     
        }

    }
}
