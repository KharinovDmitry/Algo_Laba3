using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CommandExecutor
    {
        public static void Execute(string input, IQueue<int> queue)
        {
            string[] commands = input.Trim().Split(" ");
            foreach (string command in commands)
            {
                switch (command[0]) 
                {
                    case '1':
                        var value = int.Parse(command.Split(",")[1]);
                        queue.Enqueue(value);
                        break;
                    case '2':
                        if(queue.isEmpty())
                        {
                            Console.WriteLine("is empty");
                        }
                        else
                        {
                            queue.Dequeue();
                        }

                        break;
                    case '3':
                        if (queue.isEmpty())
                        {
                            Console.WriteLine("Is empty");
                        }
                        else
                        {
                            Console.WriteLine(queue.GetHead());
                        }
                        break;
                    case '4':
                        Console.WriteLine(queue.isEmpty() ? "Empty" : "Not empty");
                        break;
                    case '5':
                        Console.WriteLine(queue);
                        break;
                }
                Console.WriteLine($"{command[0]} - выполнено, состояние очереди:");
                Console.WriteLine(queue);
            }
        }
    }
}
