using Autofac.Core;
using Domain.Entities.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DataContextInjection
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services,
            Action<DbContextOptionsBuilder>? optionsAction = null,
            ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
            ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
        {
            services.AddDbContext<DataContext>(optionsAction,contextLifetime,optionsLifetime);

            services.AddIdentityCore<MoticvUser>()
                    .AddRoles<MoticvRole>()
                    .AddEntityFrameworkStores<DataContext>()
                    .AddDefaultTokenProviders()
                    .AddUserManager<UserManager<MoticvUser>>()
                    .AddSignInManager<SignInManager<MoticvUser>>()
                    .AddRoleManager<RoleManager<MoticvRole>>();

            return services;
        }
    }
}
