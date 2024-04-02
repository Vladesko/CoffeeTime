using Application.Common.Behaviors;
using Application.Common.Validation.Command.Create;
using Application.Common.Validation.Command.Delete;
using Application.Common.Validation.Command.Update;
using Application.Common.Validation.Query.GetDetailsOrder;
using Application.Interfaces;
using Application.Orders.Commands;
using Application.Orders.Quries;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;


namespace Application.Common.Dependenies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
