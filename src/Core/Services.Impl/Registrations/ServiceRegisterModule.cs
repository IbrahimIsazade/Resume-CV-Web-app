using Autofac;
using Domain.Entities.Membership;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace Services.Impl.Registrations
{
    public class ServiceRegisterModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var types = this.GetType().Assembly.GetTypes()
                .Where(m => m.IsClass)
                .Select(m => new
                {
                    Type = m,
                    IsSingleton = m.IsDefined(typeof(SingletonLifeTImeAttribute))
                });

            builder.RegisterTypes(types.Where(m => m.IsSingleton).Select(m => m.Type).ToArray())
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterTypes(types.Where(m => m.IsSingleton == false).Select(m => m.Type).ToArray())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType(typeof(UserManager<MoticvUser>))
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType(typeof(RoleManager<MoticvRole>))
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType(typeof(SignInManager<MoticvUser>))
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
