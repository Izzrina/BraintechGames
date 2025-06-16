using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraintechGames
{
    internal static class MathQuiz
    {
        private static int AskSingleQuestion()
        {
            RandomMathProblem problem = RandomMathProblem.GenerateRandomOperation();
            while (true)
            {
                problem.printProblem();
                string input = Console.ReadLine();
                if (int.TryParse(input, out int answer))
                {
                    if (problem.CheckAnswer(answer))
                    {
                        Console.WriteLine("Right!");
                        return 2;
                    }
                    else
                    {
                        Console.WriteLine($"Wrong! The correct Answer is {problem.Result}");
                        return -2;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }
        }

        public static void PlayMathQuiz(Player currentPlayer)
        {
            int score = 0;
            int correctAnswers = 0;
            for (int i = 1; i <= 5; i++)
            {
                int result = AskSingleQuestion();
                score += result;
                if (result > 0) correctAnswers++;

            }
            Console.WriteLine($"\nQuiz finished! Your score: {score} points.");
            Console.WriteLine($"You answered {correctAnswers} of 5 questions correctly");
            PlayerManager.SavePlayerMathScore(currentPlayer, score);
            currentPlayer.AddMathScore(score);
        }
    }
}
