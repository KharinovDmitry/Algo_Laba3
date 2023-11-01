using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Core
{
    public class FileLogic
    {
        public const string PathToGeneratedData = "../. ./../DynamicStructure.FileWorker/stack100kk.txt";
        public const string PathToTimeFile = "../../../DynamicStructure .FileWorker/stack_timel6kk.txt";
        public const string PathToMemoryFile = "../../../ DynamicStructure.FileWorker / stack_menoryS0k.txt";

        //private st

        public static string[] ReadFile(string pathToFile)
        {
            return File.ReadAllLines(pathToFile);
        }

        public static void WriteFile(string pathToFile, BigInteger countoperations)
        {

            //FileGenerator fileGenerator = new FileGenerator();
            //File.AppendAllText(pathToFile, fileGenerator.GenerateFile(countoperations).Tostring());
        }


        public void ExecuteMeasurements(string pathToFileData, string pathToFileMemory, string pathToFileTime)
        {
            List<string> outputDataMemory = new();
            outputDataMemory.Add(new string("Memory"));
            List<string> outputDataTime = new();
            outputDataTime.Add(new string("Time"));

            //PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available Mbytes");
            //outputDataMemory.Add(ramCounter.RawValue.ToString());

            Stack<string> stack = new Stack<string>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var item in FileLogic.ReadFile(pathToFileData))
            {
                var items = item.Split(" ");
                for (int i = 0; i < items.Count(); i++)
                {
                    if (i / 500 == 0)
                    {
                        outputDataTime.Add(stopwatch.Elapsed.TotalMilliseconds.ToString());
                        //outputDataMemory.Add(ramCounter.RamValue.ToString());
                    }

                    if (items[i].Contains(","))
                    {
                        stack.Push(items[i].Substring(items[i].IndexOf(",") + 1));
                    }
                    else
                    {
                        switch (items[i])
                        {
                            case "2":
                                stack.Pop();
                                break;
                            case "3":
                                stack.Peek();
                                break;
                            case "4":
                                stack.IsEmpty();
                                break;
                            case "5":
                                stack.Print();
                                break;
                        }
                    }
                }
            }
            File.AppendAllLines(pathToFileMemory, outputDataMemory);
            File.AppendAllLines(pathToFileTime, outputDataTime);
            stopwatch.Stop();
        }
        public StringBuilder GenerateFile(BigInteger countOperation)
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();

            string[] data = generateMeasurementsData(countOperation - (countOperation / 2), 10, countOperation, 999);

            for (int i = 0; i < countOperation; i++)
            {
                int value = rand.Next(1, 6);
                if (value == 1)
                {
                    sb.Append("1, ");
                    sb.Append(data[i]);
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(value.ToString());
                    sb.Append(" ");
                }
            }
            return sb;
        }

        private string generateMeasurementsData(BigInteger countWords, BigInteger lengthLetters, BigInteger countNumbers, BigInteger maxNumber)
        {

            StringBuilder strItems = new StringBuilder();

            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVKYZabcdefghijklmnopqrstuvwxyz".ToCharArray();


            Random rand = new Random();


            for (int i = 1; i <= countWords; i++)
            {
                string word = " ";
                for (int j = 1; j <= lengthLetters; j++)
                {


                    int letter_num = rand.Next(0, letters.Length - 1);


                    word += letters[letter_num];
                }
                strItems.Append(word);
                strItems.Append(" ");
            }

            for (int i = 0; i < countNumbers; i++)
            {
                strItems.Append(rand.Next(0, ((int)maxNumber)).ToString());
                if ((i != countNumbers - 1))
                {
                    strItems.Append(" ");
                }
            }
            return strItems.ToString()
                .Split(" ");
        }
    }
}
