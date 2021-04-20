using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Data;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using Persistence.Services;

namespace Persistence
{
    public static class DependencyIntegration
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddDbContext<MoviesDBContext>(options =>
                  options.UseSqlite(configuration.GetConnectionString("MoviesSqliteContext"), b => b.MigrationsAssembly(typeof(MoviesDBContext).Assembly.FullName)));
            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<MoviesDBContext>());

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            
        }
    }
}