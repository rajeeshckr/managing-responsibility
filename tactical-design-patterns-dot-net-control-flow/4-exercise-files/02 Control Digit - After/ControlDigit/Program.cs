using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlDigit
{
    class Program
    {
        static int CalculateControlDigit(long number)
        {

            int sum = 
                number
                .GetDigitsFromLeastSignificant()
                .AddWeights(MultiplicativeFactors)
                .Sum();

            int result = sum % 11;
            if (result == 10)
                result = 1;

            return result;

        }

        private static IEnumerable<int> MultiplicativeFactors
        {
            get
            {
                return new int[] { 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3 };
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("{0}", CalculateControlDigit(82712476));
            Console.ReadLine();
        }
    }
}
