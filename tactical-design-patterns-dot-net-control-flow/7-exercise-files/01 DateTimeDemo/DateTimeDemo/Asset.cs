using System;

namespace DateTimeDemo
{
    class Asset
    {
        private Stock Stock { get; }
        private int Quantity { get; }
        private DateTime PurchasedAt { get; }

        public Asset(Stock stock, int quantity)
        {
            this.Stock = stock;
            this.Quantity = quantity;
            this.PurchasedAt = DateTime.UtcNow;
        }

        public Investment Sell()
        {
            return new Investment(this.Stock, this.PurchasedAt, this.Quantity);
        }

        public override string ToString()
        {
            return string.Format("{0} x {1}", this.Quantity, this.Stock);
        }
    }
}
