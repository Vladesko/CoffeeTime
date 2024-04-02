using App.Interfaces;
using App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace App.Comon
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppliaction(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
