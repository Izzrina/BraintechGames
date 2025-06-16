using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BraintechGames
{
    internal class RandomMathProblem
    {
        //Static weil für alle Objekte gleich
        private static readonly char[] operators = { '+', '-', '*', '/' };

        public int Operand1 { get; }
        public int Operand2 { get; }
        public char Operator { get; }
        public int Result { get; }


        public RandomMathProblem(int op1, int op2, char op, int res)
        {
            Operand1 = op1;
            Operand2 = op2;
            Result = res;
            Operator = op;
        }

        public static RandomMathProblem GenerateRandomOperation()
        {
            var random = new Random();
            int op1 = 0, op2 = 0, res = 0;
            char op = operators[random.Next(0, operators.Length)];
            switch (op)
            {
                case '+':
                    op1 = random.Next(1, 100);
                    op2 = random.Next(1, 100);
                    res = op1 + op2;
                    break;
                case '-':
                    op1 = random.Next(1, 100);
                    op2 = random.Next(1, 100);
                    res = op1 - op2;
                    break;
                case '*':
                    op1 = random.Next(1, 13);
                    op2 = random.Next(1, 13);
                    res = op1 * op2;
                    break;
                case '/':
                    op2 = random.Next(1, 13);
                    res = random.Next(1, 13);
                    op1 = res * op2;
                    break;
            }
            return new RandomMathProblem(op1, op2, op, res);
        }
        public void printProblem()
        {
            Console.Write($"{Operand1} {Operator} {Operand2} = ");
        }

        public bool CheckAnswer(int userAnswer)
        {
            return userAnswer == Result;
        }
    }
}
