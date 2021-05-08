using ApplicationCore.Common.Interfaces.Repositories;
using ApplicationCore.Common.Interfaces.SeedData;
using ApplicationCore.Common.Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Data;
using Persistence.Identity;
using Persistence.Seed;
using Persistence.Services;
using System;

namespace Persistence
{
    public static class DependencyIntegration
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {   
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddDbContext<MoviesDBContext>(options =>
                  options.UseSqlite(configuration.GetConnectionString("MoviesSqliteConnection"), b => b.MigrationsAssembly(typeof(MoviesDBContext).Assembly.FullName)));

            services.AddDbContext<AppIdentityDbContext>(options =>
                  options.UseSqlite(configuration.GetConnectionString("IdentitySqliteConnection"), b => b.MigrationsAssembly(typeof(AppIdentityDbContext).Assembly.FullName)));

            //services.AddScoped<IMoviesDbContext>(provider => provider.GetService<MoviesDBContext>());
            services.AddScoped<IDomainEventService, DomainEventService>();

            
            ConfigureCookieSettings(services);

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            }).AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ISeedData, IdentitySeedData>();
            services.AddTransient<ISeedData, MoviesSeedData>();            
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));            
        }

        private static void ConfigureCookieSettings(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.Always,
                    IsEssential = true // required for auth to work without explicit user consent; adjust to suit your privacy policy
                };
            });
        }
    }
}