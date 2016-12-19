using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IteratorDemo
{
    class Program
    {
        static IEnumerable<int> Populate(int max)
        {
            for (int i = 1; i <= max; i++)
                yield return i;
        }

        static void Main(string[] args)
        {

            int n = 100000000;
            long sum = 0;
            Stopwatch sw = Stopwatch.StartNew();
            int stopAt = 10000000;

            foreach (int value in Populate(n))
            {
                sum += value;
                if (value % stopAt == 0)
                {
                    Console.WriteLine("{0}M\tMem={1}Mbyte\tTime={2}msec",
                                      value / 1000000, GC.GetTotalMemory(false) / 1024 / 1024,
                                      sw.ElapsedMilliseconds);
                }
            }

            long expectedSum = (long)n * ((long)n + 1) / 2;
            Console.WriteLine("Sum {{1.. {0:#,##0}}} = {1:#,##0}; expected {2:#,##0}",
                              n, sum, expectedSum);
            Console.ReadLine();

        }
    }
}
