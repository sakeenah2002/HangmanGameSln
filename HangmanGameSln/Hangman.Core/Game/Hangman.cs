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
        private string[] _wordArray = { "twenty" };//, "random", "education", "population", "champagne", "breakfast", "chocolate", "landscape", "ritual", "professional", "lesson", "cruel", "crime", "prisoner", "shareholder", " pyramid", " vampire", "werewolf", "mermaid", "demigod", "queen", "reign", "fairy", " bisexual", "asexual", "lesbian", "transgender" };


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
                Console.Write("Amount of letters in the word : ");
                Console.WriteLine(_progress.Length);
                Console.SetCursorPosition(0, 15);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("What is your next guess: ");
                var nextGuess = Console.ReadLine();
                Console.WriteLine(_progress);

                       
                if (bodyparts == 0)

                while (true)
                {
                    Console.WriteLine("Please enter next guess:");
                    string nextguess = Console.ReadLine();

                    progressArray(nextguess[0]);

                    Console.WriteLine(_progress);
                }
                for (int i = 0; i < _yourguesswords.Length; i++)
                {

                    if (_yourguesswords.Contains(_progress))
                    {

                    }
                    else if (!_yourguesswords.Contains(_progress))
                    {
                        bodyparts--;

                        break;
                    }

                }
            }
               
                                     
        }

    }
}
