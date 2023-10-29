using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Analyzer
    {

        public static AnalyzeResult Evaluate(IQueue<int> queue, int count, int length)
        {
            string algoName = queue.GetType().Name;
            Console.WriteLine($"{algoName} Старт");

            AnalyzeResult report = new AnalyzeResult($"{algoName}, длина: {length}");
            for (int n = 1; n < count; n++)
            {
                queue.Clear();
                string commands = GenerateCommands(length);
                Console.WriteLine($"Вход: {commands}");
                Console.WriteLine($"{n}ый - Запуск");
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                CommandExecutor.Execute(commands, queue);                           
                sw.Stop();
                report.AddMeasurement(n, sw.ElapsedMilliseconds);
            }

            Console.WriteLine($"{algoName} Done");
            return report;
        }

        public static AnalyzeResult Evaluate(IQueue<int> queue, int count)
        {
            string algoName = queue.GetType().Name;
            Console.WriteLine($"{algoName} Старт");

            AnalyzeResult report = new AnalyzeResult(algoName);
            for (int n = 1; n < count; n++)
            {
                queue.Clear();
                string commands = GenerateCommands(n);
                Console.WriteLine($"Вход: {commands}");
                Console.WriteLine($"{n}ый - Запуск");
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                CommandExecutor.Execute(commands, queue);
                sw.Stop();
                report.AddMeasurement(n, sw.ElapsedMilliseconds);
            }

            Console.WriteLine($"{algoName} Done");
            return report;
        }

        private static string GenerateCommands(int length)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                int command = new Random().Next(1, 5);
                if(command == 1)
                {
                    sb.Append(command.ToString() + "," + new Random().Next(0, 100));
                    count++;
                }
                else
                {
                    if(count == 0 && (command == 2 || command == 3))
                    {
                        sb.Append(new Random().Next(4,5));
                    }
                    else
                    {
                        if (command == 2)
                        {
                            count--;
                        }
                        sb.Append(command.ToString());
                    }
                }
                sb.Append(" ");
            }
            return sb.ToString().Trim();
        }
    }
}
