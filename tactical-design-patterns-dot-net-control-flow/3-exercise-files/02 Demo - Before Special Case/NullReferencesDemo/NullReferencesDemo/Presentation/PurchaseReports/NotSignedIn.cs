using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    internal class NotSignedIn : IPurchaseReport
    {
        public string ToUiText()
        {
            return "No user is signed in.";
        }
    }
}
