using System;

namespace ControlFlowDemo
{
    class Program
    {

        static decimal GetItemPrice(string itemName)
        {
            return 100.0M * itemName.Length;
        }

        static decimal GetItemPrice(string itemName, decimal relativeDiscount)
        {

            if (relativeDiscount <= 0 || relativeDiscount >= 1)
            {
                throw new ArgumentException("Incorrect discount.", "relativeDiscount");
            }

            Console.WriteLine("LOG Discount {0}% applied.", 100 * relativeDiscount);

            return GetItemPrice(itemName) * (1.0M - relativeDiscount);

        }

        static void Main(string[] args)
        {
            Console.WriteLine("{0:C}", GetItemPrice("laptop", .15M));
            Console.WriteLine("{0:C}", GetItemPrice("pen", 0));
            Console.ReadLine();
        }
    }
}
