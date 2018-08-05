using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    enum Selection { rock = 1, paper, scissors }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
        }
    }

    class Game
    {
        private bool LoopGame { get; set; }
        private string UserInput { get; set; }
        private Selection UserSelection { get; set; }
        private Throw UserFist { get; set; }
        private Throw OpponentFist { get; set; }
        private double Outcome { get; set; }

        public Game()
        {
            LoopGame = true;
            Loop();
        }

        private void Loop()
        {
            while (LoopGame == true)
            {
                WelcomeUser();
                GetSelection();
                CreateThrows();
                PrintThrows();
                CheckWin();
                CheckReplay();
            }
        }

        private void WelcomeUser()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Rock, Paper, Scissors!\n");
            Console.Write(@"Please enter ""Rock"", ""Paper"", or ""Scissors"" to begin: ");
        }

        private void GetSelection()
        {
            string userInput = Console.ReadLine().ToLower();

            while (userInput != "rock" && userInput != "paper" && userInput != "scissors" && userInput != "")
            {
                Console.Clear();
                Console.Write(@"Please enter ""Rock"", ""Paper"", or ""Scissors"" to begin: ");
                userInput = Console.ReadLine().ToLower();
            }

            UserInput = userInput;
            Enum.TryParse(UserInput, out Selection userSelection);
            UserSelection = userSelection;
        }

        private void CreateThrows()
        {
            UserFist = new Throw(UserSelection);
            OpponentFist = new Throw();
        }

        private void PrintThrows()
        {
            Console.WriteLine($"\nUser choice: {(int)UserFist.Choice} {UserFist.Choice}");
            Console.WriteLine($"Opponent choice: {(int)OpponentFist.Choice} {OpponentFist.Choice}");
        }

        private void CheckWin()
        {
            Outcome = Math.Round(((double)UserFist.Choice / (double)OpponentFist.Choice), 1);
            Console.WriteLine("Outcome value: " + Outcome);

            switch (Outcome)
            {
                case 0.3:
                case 2:
                case 1.5:
                    Console.WriteLine("\nYou Win!!!\n");
                    break;

                case 0.5:
                case 0.7:
                case 3:
                    Console.WriteLine("\nYou Lose...\n");
                    break;

                default:
                    Console.WriteLine("\nIt's a draw!\n");
                    break;
            }
        }

        private void CheckReplay()
        {
            Console.Write("Play Again? [Y]/N: ");
            if (Console.ReadLine().ToLower().Contains("n") == true)
            {
                LoopGame = false;
            }
        }

        class Throw
        {
            private static readonly Random Rand = new Random();
            public Selection Choice { get; set; }

            public Throw()
            {
                GetRandom();
            }

            public Throw(Selection choice)
            {
                if (choice == 0)
                {
                    GetRandom();
                }
                else
                {
                    Choice = choice;
                }
            }

            private void GetRandom()
            {
                int number = Rand.Next(1, 4);
                Choice = (Selection)number;
            }
        }
    }
}
