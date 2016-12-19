using System;
using System.Collections.Generic;
using System.Linq;

namespace DateTimeDemo
{
    class Stock
    {

        private IList<StockPrice> PriceHistory { get; }

        public Stock(decimal initialPrice)
        {
            this.PriceHistory = new List<StockPrice>();
            this.SetPrice(initialPrice);
        }

        public void SetPrice(decimal price)
        {
            this.PriceHistory.Add(new StockPrice(price));
        }

        public decimal GetPriceAt(DateTime time)
        {
            return this.PriceHistory
                .Where(price => price.ValidFrom <= time)
                .OrderByDescending(price => price.ValidFrom)
                .First()
                .Price;
        }

        public override string ToString()
        {
            return string.Format("{0:C} at {1:MM-dd-yyyy HH:mm:ss.ffff}",
                this.GetPriceAt(DateTime.UtcNow),
                DateTime.UtcNow);
        }
    }
}
