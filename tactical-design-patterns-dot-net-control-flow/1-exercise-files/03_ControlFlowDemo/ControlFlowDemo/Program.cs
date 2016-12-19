using System;

namespace ControlFlowDemo
{

    class Discount
    {
        private readonly string description;
        private readonly decimal relativeDiscount;

        public Discount(string description, decimal relativeDiscount)
        {

            if (relativeDiscount <= 0 || relativeDiscount >= 1)
            {
                throw new ArgumentException("Invalid discount.", "relativeDiscount");
            }

            this.description = description;
            this.relativeDiscount = relativeDiscount;

        }

        public decimal Apply(decimal price)
        {
            return price * (1 - this.relativeDiscount);
        }

        public override string ToString()
        {
            return string.Format("{0}% {1}", this.relativeDiscount * 100, this.description);
        }
    }

    class Program
    {

        static decimal GetItemPrice(string itemName)
        {
            return 100.0M * itemName.Length;
        }

        static decimal GetItemPrice(string itemName, Discount discount)
        {

            if (discount == null)
            {
                throw new ArgumentNullException("discount");
            }

            Console.WriteLine("LOG applying {0}", discount);

            decimal basePrice = 100.0M * itemName.Length;
            return discount.Apply(basePrice);
            
        }

        static void Main(string[] args)
        {
            
            Discount discount = new Discount("loyalty discount", 0.15M);

            Console.WriteLine("{0:C}", GetItemPrice("laptop", discount));
            Console.WriteLine("{0:C}", GetItemPrice("pen"));

            Console.ReadLine();

        }
    }
}
