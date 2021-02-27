using ApplicationCore.Interfaces.Services;
using Domain.Entity;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationCore
{
    public static class DependencyInjection
    {
        public static void AddApplicationCore(this IServiceCollection services)
        {
            services.AddMediatR(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}
