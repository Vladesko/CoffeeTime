using App.Interfaces;
using App.Services;
using Infastructure.Comons.Exceptions;
using Infastructure.Entities;
using Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Comons
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            string connectionString = string.Empty;

            using (var sr = new StreamReader("D:\\Passwords\\ConnectionString.txt", Encoding.UTF8, false))
            {
                connectionString = sr.ReadToEnd();
            }
            services.AddDbContext<AuthorizeDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtProvider,JwtProvider>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
