using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    public class Receipt: IPurchaseReport
    {
        private readonly string username;
        private readonly string productName;
        private readonly decimal price;

        public Receipt(string username, string productName, decimal price)
        {
            this.username = username;
            this.productName = productName;
            this.price = price;
        }

        public string ToUiText()
        {
            return string.Format("Dear {0},\nThank you for buying {1} for {2:C}.",
                                 this.username, this.productName, this.price);
        }
    }
}
