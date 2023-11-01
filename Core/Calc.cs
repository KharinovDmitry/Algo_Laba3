using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Calc
    {
        public static double CalculateRPN(List<string> rpn)
        {
            if (rpn.Count == 0)
            {
                throw new ArgumentException("Invalid number of values");
            }

            Stack<double> calc = new Stack<double>();
            foreach (var element in rpn)
            {
                double.TryParse(element, out double doubleValue);
                if (doubleValue != 0)
                {
                    calc.Push(doubleValue);
                }
                else if (IsOperation(element))
                {
                    if (calc.Count() < 2)
                    {
                        double first = (double) calc.Pop();
                        calc.Push(CalculateOperation(first: first, operation: element));
                    }
                    else
                    {
                        double second = (double) calc.Pop();
                        double first = (double) calc.Pop();

                        calc.Push(CalculateOperation(first: first, second: second, operation: element));
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid value");
                }
            }

            return (double) calc.Pop();
        }

        private static double CalculateOperation(double first, string operation, double second = 0)
        {
            switch (operation)
            {
                case "+":
                    return first + second;
                case "-":
                    return first - second;
                case "/":
                    return first / second;
                case "*":
                    return first * second;
                case "ln":
                    return Math.Log(first);
                case "cos":
                    return Math.Cos(first);
                case "^":
                    return Math.Pow(first, second);
                default:
                    throw new Exception("Invalid operation");
            }
        }

        private static bool IsOperation(string operation) => operation.Equals("+")
                                                             || operation.Equals("-")
                                                             || operation.Equals("=")
                                                             || operation.Equals("/")
                                                             || operation.Equals("*")
                                                             || operation.Equals("^")
                                                             || operation.Equals("ln")
                                                             || operation.Equals("cos");
    }
}
