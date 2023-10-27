using System;
using System.Collections.Generic;
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
            var queue = new Core.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine(queue);
        }
    }
}
