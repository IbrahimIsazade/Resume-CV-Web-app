using Autofac;
using Autofac.Extensions.DependencyInjection;
using Persistence;

namespace WebUI
{
    public class IoCFactory : AutofacServiceProviderFactory
    {
        public IoCFactory()
            :base(Register)
        {
            
        }

        private static void Register(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceRegisterModule>();
        }
    }
}
