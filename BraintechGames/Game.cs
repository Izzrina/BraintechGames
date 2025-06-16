using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BraintechGames
{
    internal class Game
    {

        public Player CurrentPlayer { get; set; }

        public void PlayGame()
        {
            ShowIntro();
            SelectPlayer();
            ShowPlayer();
            ChooseGame();
            // ChooseGame();
            // StartGameLoop()
        }
        private void ShowIntro()
        {
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("        *** Welcome to BRAINTECH GAMES! ***\n");
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("Get ready to put your brain to the test!");
            Console.WriteLine("In this challenge, you'll face a series of fun and engaging puzzles designed to sharpen your thinking skills.\n");
            Console.WriteLine("Choose between two exciting categories:");
            Console.WriteLine("1. Math Puzzles – Solve quick calculations and prove your number skills.");
            Console.WriteLine("2. Logic Puzzles – Tackle tricky questions that test your reasoning and knowledge.\n");
            Console.WriteLine("Scoring System:");
            Console.WriteLine("- Correct answers earn you points.");
            Console.WriteLine("- Wrong answers will cost you points, so think carefully!\n");
            Console.WriteLine("Aim high and challenge yourself to get the best possible score!");
            Console.WriteLine("Are you ready to begin your puzzle adventure? Let’s get started!\n");
            Console.WriteLine("To start, please choose your player profile.");
        }

        private void SelectPlayer()
        {
            while (CurrentPlayer == null)
            {
                Console.WriteLine("Please choose one of the following options:");
                Console.WriteLine("1 Create a new player  2 Select an existing player  exit Quit the game");

                string option = Console.ReadLine();
                if (option == "1")
                {
                    CurrentPlayer = PlayerManager.AddNewPlayer();
                }
                else if (option == "2")
                {
                    CurrentPlayer = PlayerManager.GetPlayer();
                }
                else if (option == "exit")
                {
                    Console.WriteLine("\nThanks for playing BRAINTECH GAMES! See you next time!");
                    Environment.Exit(0); // Programm sofort beenden
                }

                Console.WriteLine("Invalid Input.");
            }
        }
        private void ShowPlayer()
        {
            Console.WriteLine("\n********************************************************");
            Console.WriteLine("             PLAYER PROFILE SUMMARY");
            Console.WriteLine("**********************************************************");
            Console.WriteLine($"Username:            {CurrentPlayer.Username}");
            Console.WriteLine($"Math Puzzle Score:   {CurrentPlayer.MathScore} points");
            Console.WriteLine($"Logic Puzzle Score:  {CurrentPlayer.LogicScore} points");
            Console.WriteLine($"-------------------------------");
            Console.WriteLine($"Total Score:         {CurrentPlayer.TotalScore} points");
            Console.WriteLine("**********************************************************\n");
        }

        private void ChooseGame()
        {
            Console.WriteLine("Now it's time to choose your challenge!");
            Console.WriteLine("Which type of puzzle would you like to play?\n");
            Console.WriteLine("1. Math Quiz    – Quick calculations and number logic.");
            Console.WriteLine("2. Logic Quiz   – Tricky multiple-choice questions that test your reasoning.\n");

            while (true)
            {
                Console.WriteLine("\nEnter your choice: 1 Start the Math Quiz   2 Multiple Choice Questions   exit  Quit the Game");
                Console.Write("Your selection: ");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    MathQuiz.PlayMathQuiz(CurrentPlayer);
                    ShowPlayer();
                }
                else if (option == "2")
                {
                    var logicQuiz = new LogicQuiz();
                    logicQuiz.PlayLogicQuiz(CurrentPlayer);
                    ShowPlayer();
                }
                else if (option == "exit")
                {
                    Console.WriteLine("\nThanks for playing BRAINTECH GAMES! See you next time!");
                    Environment.Exit(0); // Programm sofort beenden
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}
