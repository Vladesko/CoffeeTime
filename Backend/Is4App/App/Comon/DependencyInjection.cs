using App.Comon.Validations;
using App.Interfaces;
using App.Services;
using DomainApp.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace App.Comon
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppliaction(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IValidator<RegistrationViewModel>, RegistrationValidator>();
            services.AddScoped<IUserValidator, UserValidator>();
            return services;
        }
    }
}
