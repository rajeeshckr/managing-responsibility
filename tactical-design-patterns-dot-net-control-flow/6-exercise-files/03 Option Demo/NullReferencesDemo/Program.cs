using NullReferencesDemo.Application.Implementation;
using NullReferencesDemo.Domain.Implementation;
using NullReferencesDemo.Infrastructure.Implementation;
using NullReferencesDemo.Presentation.Implementation;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.PurchaseReports;

namespace NullReferencesDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            IPurchaseReportFactory reportFactory = new PurchaseReportFactory();

            UserInterface ui = 
                new UserInterface(
                    new ApplicationServices(
                        new DomainServices(
                            new UserRepository(),
                            new ProductRepository(),
                            reportFactory),
                        reportFactory));

            while (ui.ReadCommand())
            {
                ui.ExecuteCommand();
            }
        }
    }

}
