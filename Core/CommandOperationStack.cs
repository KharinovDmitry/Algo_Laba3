using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CommandOperationStack
    {
        public static void DoOperation(string operationNumber)
        {
            Stack<object> stack = new Stack<object>();
            List<string> numbers = operationNumber.Split(" ").ToList().Where(x => !x.Equals(string.Empty)).ToList();
            foreach (var num in numbers)
            {
                string currNum = num.Trim();

                if (num.Length > 1)
                {
                    string[] operation = currNum.Split(",");
                    CommandExecutorStack(stack: stack, operationNumber: operation[0], value: operation[1]);
                }
                else
                {
                    CommandExecutorStack(stack: stack, operationNumber: currNum);
                }
            }
        }
        public static void CommandExecutorStack(Stack<object> stack, string operationNumber, string value = "")
        {
            int.TryParse(value, out int numValue);
            switch (operationNumber)
            {
                case "1":
                    Console.WriteLine($"Push {value}");
                    stack.Push(numValue != 0 ? numValue : value);
                    break;
                case "2":
                    Console.WriteLine($"Pop {stack.Pop()}");
                    break;
                case "3":
                    Console.WriteLine($"Top {stack.Peek()}");
                    break;
                case "4":
                    Console.WriteLine("IsEmpty");
                    stack.IsEmpty();
                    break;
                case "5":
                    Console.WriteLine("Print");
                    stack.Print();
                    break;
                default:
                    throw new Exception("Invalid operation");
            }
        }
    }
}
