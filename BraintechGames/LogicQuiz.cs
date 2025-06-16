using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BraintechGames
{
    internal class LogicQuiz
    {
        private const string FilePath = "questions.json";
        private List<LogicQuestion> allQuestions;
        private List<LogicQuestion> selectedQuestions;
        private int points;

        public LogicQuiz()
        {
            allQuestions = LoadQuestionsFromJson(FilePath);
            selectedQuestions = GetRandomQuestions(5);
        }

        private List<LogicQuestion> LoadQuestionsFromJson(string filepath)
        {
            string json = File.ReadAllText(filepath);
            return JsonSerializer.Deserialize<List<LogicQuestion>>(json);
        }

        private List<LogicQuestion> GetRandomQuestions(int numberQuestions)
        {
            Random random = new Random();
            //Kopie der geladenen Liste
            List<LogicQuestion> remainingQuestions = new List<LogicQuestion>(allQuestions);
            List<LogicQuestion> selectedQuestions = new List<LogicQuestion>();

            for (int i = 0; i < numberQuestions && remainingQuestions.Count > 0; i++)
            {
                int index = random.Next(remainingQuestions.Count);
                selectedQuestions.Add(remainingQuestions[index]);
                remainingQuestions.RemoveAt(index);
            }

            return selectedQuestions;
        }

        public void PlayLogicQuiz(Player player)
        {
            Console.WriteLine("Welcome to the Quiz!\n");
            int score = 0;
            int correctAnswers = 0;

            for (int i = 0; i < selectedQuestions.Count; i++)
            {
                var question = selectedQuestions[i];
                question.printQuestion();
                while (true)
                {
                    Console.Write("Your answer (1-4): ");
                    if (int.TryParse(Console.ReadLine(), out int eingabe) && eingabe >= 1 && eingabe <= question.Answers.Count)
                    {
                        if (eingabe - 1 == question.IndexSolution)
                        {
                            Console.WriteLine("Correct Answer!\n");
                            score += 2;
                            correctAnswers++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Wrong! Correct answer: {question.Answers[question.IndexSolution]}\n");
                            score -= 2;
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Try again.\n");
                    }
                }
            }
            Console.WriteLine($"\nQuiz finished! Your score: {score} points.");
            Console.WriteLine($"You answered {correctAnswers} of 5 questions correctly");
            PlayerManager.SavePlayerLogicScore(player, score);
            player.AddLogicScore(score);

        }
    }
}
