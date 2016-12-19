using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    internal class FailedPurchase: IPurchaseReport
    {
        
        private static FailedPurchase instance;

        private FailedPurchase()
        { 
        }

        public static FailedPurchase Instance
        {
            get
            {
                if (instance == null)
                    instance = new FailedPurchase();
                return instance;
            }
        }

        public string ToUiText()
        {
            return "Purchase failed.";
        }
    }
}
