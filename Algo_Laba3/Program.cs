using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Algo_Laba3
{
    internal class Program
    {
        public static string ReadFile(string fileName) => File.ReadAllText($"..\\..\\..\\..\\{fileName}");
        public static void Main(string[] args)
        {
            //EvaluateQueue();
            while(true)
            {
                Console.Clear();    
                Core.Queue<int> queue = new Core.Queue<int>();
                Console.WriteLine("Введите команды");
                CommandExecutor.Execute(Console.ReadLine(), queue);
                Console.ReadKey();
            }
            /* Для калькулятора:
            var inputFileLine = ReadFile("inputForCalc.txt");
            List<string> operation = inputFileLine.Split(" ").ToList().Where(x => !x.Equals(string.Empty)).ToList();
            double result = Calc.CalculateRPN(operation);
            Console.WriteLine(result);
            
            Для стека:
            var inputFileLine = ReadFile("inputForStack.txt");
            CommandOperationStack.DoOperation(inputFileLine);
            */
        }

        public static void EvaluateQueue()
        {
            List<AnalyzeResult> res = new List<AnalyzeResult>();
            Core.Queue<int> queue = new Core.Queue<int>();
            res.Add(Analyzer.Evaluate(queue, 1000, 10));
            res.Add(Analyzer.Evaluate(queue, 1000));
            QueueAlias<int> queueAlias = new QueueAlias<int>();
            res.Add(Analyzer.Evaluate(queueAlias, 1000, 10));
            res.Add(Analyzer.Evaluate(queueAlias, 1000));
            res.ForEach(q => CsvWriter.WriteAnalyzeResult(q));
        }
    }
}
