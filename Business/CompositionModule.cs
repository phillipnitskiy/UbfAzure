using Business.Interfacies.Interfacies;
using Business.Servicies;
using Microsoft.Practices.Unity;

namespace Business
{
    public class CompositionModule : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUbfService, UbfService>();
        }
    }
}
