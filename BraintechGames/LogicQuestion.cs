using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BraintechGames
{
    internal class LogicQuestion
    {

        public string Question { get; set; }
        public List<string> Answers { get; set; }
        public int IndexSolution { get; set; }

        public void printQuestion()
        {
            Console.WriteLine($"\n{Question}");
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}  {Answers[i]}");
            }
            Console.WriteLine("\n");
        }

    }
}
