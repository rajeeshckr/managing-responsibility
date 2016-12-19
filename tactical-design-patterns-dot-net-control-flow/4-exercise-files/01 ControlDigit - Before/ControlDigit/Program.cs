using System;

namespace ControlDigit
{
    class Program
    {
        static int CalculateControlDigit(long number)
        {

            int sum = 0;
            int factor = 1;

            do
            {

                int digit = (int)(number % 10);
                sum += factor * digit;
                factor = 4 - factor;
                number /= 10;

            }
            while (number > 0);

            int result = sum % 11;
            if (result == 10)
                result = 1;

            return result;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("{0}", CalculateControlDigit(82712476));
            Console.ReadLine();
        }
    }
}
