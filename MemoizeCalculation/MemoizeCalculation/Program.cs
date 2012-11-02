using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoizeCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new MemoizedPrimeCalculation();
            var vals = Enumerable.Range(2, 1000).Where(val => calc.Calculation(val));

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            foreach(var val in vals)
            {
                Console.WriteLine(val + ": Prime");
            }
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine(sw.ElapsedMilliseconds + "[ms]");

            Console.Read();
        }
    }
}
