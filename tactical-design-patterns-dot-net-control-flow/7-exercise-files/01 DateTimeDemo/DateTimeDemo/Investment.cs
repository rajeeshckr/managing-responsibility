using System;

namespace DateTimeDemo
{
    class Investment
    {
        private Stock Stock { get; }
        private DateTime PurchasedAt { get; }
        private DateTime SoldAt { get; }
        private int Quantity { get; }

        public Investment(Stock stock, DateTime purchasedAt, int quantity)
        {
            this.Stock = stock;
            this.PurchasedAt = purchasedAt;
            this.SoldAt = DateTime.UtcNow;
            this.Quantity = quantity;
        }

        public decimal Profit
        {
            get
            {

                decimal buyPrice = this.Stock.GetPriceAt(this.PurchasedAt) * this.Quantity;
                decimal sellPrice = this.Stock.GetPriceAt(this.SoldAt) * this.Quantity;

                return sellPrice - buyPrice;

            }
        }
    }
}
