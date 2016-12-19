using NullReferencesDemo.Application.Implementation;
using NullReferencesDemo.Domain.Implementation;
using NullReferencesDemo.Infrastructure.Implementation;
using NullReferencesDemo.Presentation.Implementation;

namespace NullReferencesDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            UserInterface ui = 
                new UserInterface(
                    new ApplicationServices(
                        new DomainServices(
                            new UserRepository(),
                            new ProductRepository())));

            while (ui.ReadCommand())
            {
                ui.ExecuteCommand();
            }
        }
    }

}
