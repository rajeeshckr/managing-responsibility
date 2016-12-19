using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    internal class NotRegistered : IPurchaseReport
    {

        private readonly string username;

        public NotRegistered(string username)
        {
            this.username = username;
        }

        public string ToUiText()
        {
            return string.Format("User {0} is not registered.", this.username);
        }
    }
}
