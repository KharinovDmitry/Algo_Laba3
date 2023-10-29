using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class AnalyzeResult
    {
        public string Title { get; }

        public List<TimeMeasurement> Measurements { get; }

        public AnalyzeResult(string title) 
        { 
            Title = title; 
            Measurements = new List<TimeMeasurement>();
        }

        public void AddMeasurement(int arrLength, double time)
        {
            Measurements.Add(new TimeMeasurement(arrLength, time));
        }

    }

    public class TimeMeasurement
    {
       public int ArrayLength { get; }
       public double TimeInS { get; }

       public TimeMeasurement(int arrayLength, double timeInMs)
        {
            ArrayLength = arrayLength;
            TimeInS = timeInMs;
        }
    }
}
