using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    internal class ProductNotFound: IPurchaseReport
    {

        private readonly string username;
        private readonly string productName;

        public ProductNotFound(string username, string productName)
        {
            this.username = username;
            this.productName = productName;
        }

        public string ToUiText()
        {
            return string.Format("Dear {0},\nSorry to inform you that we have no {1} left.", this.username, this.productName);
        }
    }
}
