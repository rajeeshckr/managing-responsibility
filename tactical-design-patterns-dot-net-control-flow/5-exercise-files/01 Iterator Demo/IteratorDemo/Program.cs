using System;
using System.Collections.Generic;

namespace IteratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            IEnumerable<int> data = new List<int>(new int[] { 1, 2, 3, 4, 5 });

            IEnumerator<int> iterator = data.GetEnumerator();
            List<int> output = new List<int>();

            while (iterator.MoveNext())
                if (iterator.Current % 2 != 0)
                    output.Add(iterator.Current);

            Console.WriteLine("{0} elements remain.", output.Count);
            Console.ReadLine();

        }
    }
}
