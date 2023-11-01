using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Algo_Laba3
{
    internal class Program
    {
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
