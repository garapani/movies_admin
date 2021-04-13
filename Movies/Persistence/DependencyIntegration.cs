using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Data;
using ApplicationCore.Interfaces.Repositories;

namespace Persistence
{
    public static class DependencyIntegration
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MoviesDBContext>(options =>
                  options.UseSqlite(configuration.GetConnectionString("MoviesSqliteContext"), b => b.MigrationsAssembly(typeof(MoviesDBContext).Assembly.FullName)));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
        }
    }
}
