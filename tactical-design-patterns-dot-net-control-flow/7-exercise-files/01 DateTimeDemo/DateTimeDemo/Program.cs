using System;
using System.Threading;

namespace DateTimeDemo
{
    class Program
    {

        static Stock InitializeSimulation(decimal initialPrice)
        {
            Console.WriteLine("Initializing stock at {0:C}\n", initialPrice);
            return new Stock(initialPrice);
        }

        static void ChangePrice(Stock stock, decimal newPrice)
        {
            Thread.Sleep(300);
            Console.WriteLine("Changing price to {0:C}", newPrice);
            stock.SetPrice(newPrice);
        }

        static Asset Buy(Stock stock, int quantity)
        {
            Thread.Sleep(200);
            Console.WriteLine("\nBuying {0} x {1}\n", quantity, stock);
            return new Asset(stock, quantity);
        }

        static Investment Sell(Asset asset)
        {

            Thread.Sleep(250);
            Console.WriteLine("\nSelling {0}\n", asset);
            Investment investment = asset.Sell();

            Console.WriteLine("Total return {0:C}\n", investment.Profit);

            return investment;

        }

        static Investment SimulateInvestment(int quantity)
        {

            Stock stock = InitializeSimulation(20.3M);

            ChangePrice(stock, 20.28M);
            ChangePrice(stock, 20.33M);
            ChangePrice(stock, 20.52M);
            ChangePrice(stock, 20.7M);

            Asset asset = Buy(stock, quantity);

            ChangePrice(stock, 20.78M);
            ChangePrice(stock, 20.82M);
            ChangePrice(stock, 20.44M);
            ChangePrice(stock, 20.12M);

            Investment investment = Sell(asset);

            return investment;

        }

        static void Test()
        {

            Investment investment = SimulateInvestment(1000);

            if (investment.Profit != -580.0M)
                Console.WriteLine("TEST FAILED");
            else
                Console.WriteLine("TEST PASSED");

        }


        static void Main(string[] args)
        {

            Test();
            Console.ReadLine();

        }
    }
}
