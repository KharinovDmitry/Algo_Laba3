using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Calculator
    {
        private static string ReadFile(string fileName) => File.ReadAllText($"..\\..\\..\\..\\{fileName}");
        static public double Calculate(string v)

        {
            var inputFileLine = ReadFile("input.txt");
            List<string> operation = inputFileLine.Split(" ").ToList().Where(x => !x.Equals(string.Empty)).ToList();
            string input = сonvertString(v);
            string output = GetExpression(input);
            double result = Calc.CalculateRPN(operation);
            return result;
        }



        static public string GetExpression(string v)
        {
            string input = сonvertString(v);
            string output = string.Empty;

            Stack<string> operStack = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {

                if (IsDelimeter(input[i]))
                    continue;

                if (input[i] == '-' && ((i > 0 && !Char.IsDigit(input[i - 1])) || i == 0))
                {
                    i++;
                    output += "-";
                }



                if (Char.IsDigit(input[i]))
                {

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    output += " ";
                    i--;
                }
                if (IsOperator(input[i]) || IsFunction(input[i].ToString()))
                {
                    if (input[i] == '(')
                        operStack.Push(input[i].ToString());
                    else if (input[i] == ')')
                    {
                        string s = (string) operStack.Pop();
                        while (s != "(")
                        {
                            output += s.ToString() + ' ';
                            s = (string) operStack.Pop();
                        }
                    }
                    else
                    {
                        if (operStack.Count() > 0)
                            if (GetPriority(input[i].ToString()) <= GetPriority(operStack.Peek()))
                                output += operStack.Pop().ToString() + " ";
                        operStack.Push((input[i].ToString()));

                    }
                }
            }

            while (operStack.Count() > 0)
                output += operStack.Pop() + " ";
            return output;
        }

        static private bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
                return true;
            return false;
        }
        static private bool IsFunction(string с)
        {
            if (("√".IndexOf(с) != -1)) return true;
            if (("s".IndexOf(с) != -1)) return true;
            if (("c".IndexOf(с) != -1)) return true;
            if (("l".IndexOf(с) != -1)) return true;
            return false;
        }
        static private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }
        static private byte GetPriority(string s)
        {
            switch (s)
            {
                case "√": return 0;
                case "s": return 1;
                case "c": return 2;
                case "l": return 3;
                case "(": return 4;
                case ")": return 5;
                case "+": return 6;
                case "-": return 7;
                case "*": return 8;
                case "/": return 9;
                case "^": return 10;
                default: return 11;
            }

        }


        static private string сonvertString(string str)
        {
            string newString = "";
            foreach (var c in str.Split(" "))
            {
                switch (c)
                {
                    case "log":
                        newString += "l ";
                        break;
                    case "sin":
                        newString += "s ";
                        break;
                    case "cos":
                        newString += "c ";
                        break;
                    case "sqrt":
                        newString += "√ ";
                        break;
                    default:
                        newString += c + " ";
                        break;
                }
            }
            return newString;
        }
    }
}

