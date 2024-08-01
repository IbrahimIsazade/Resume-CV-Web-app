using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Categories;
using Services.ContactPost;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new IoCFactory());
             
            builder.Services.AddControllersWithViews( cfg =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                cfg.Filters.Add(new AuthorizeFilter(policy));
            });

            builder.Services.AddDataContext(cfg =>
            {
                cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"), opt =>
                {
                    opt.MigrationsHistoryTable("MigrationHistory");
                });
            });

            builder.Services.AddFluentValidationAutoValidation(cfg =>
            {
                cfg.DisableDataAnnotationsValidation = false;
            });

            builder.Services.AddValidatorsFromAssemblyContaining<AddContactPostRequestDtoValidator>(includeInternalTypes: true);
            builder.Services.AddValidatorsFromAssemblyContaining<AddCategoryRequestDtoValidator>(includeInternalTypes: true);

            //builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthentication( cfg =>
            {
                cfg.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(cfg =>
            {
                cfg.LoginPath = "/login.html";

                cfg.Cookie.Name = "Moticv";
                cfg.Cookie.HttpOnly = true;
            });
            builder.Services.AddAuthorization();

            builder.Services.Configure<IdentityOptions>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;

                //cfg.Lockout.AllowedForNewUsers = false;
                cfg.Lockout.MaxFailedAccessAttempts = 5;
                cfg.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            });

            var app = builder.Build();
            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapAreaControllerRoute(
                name: "admin",
                areaName: "Admin",
                pattern: "Admin/{controller=Categories}/{action=Categories}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
