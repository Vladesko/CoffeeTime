using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Common.Dependenies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            string connectionString = string.Empty;

            using (var sr = new StreamReader("D:\\Passwords\\ConnectionString.txt", Encoding.UTF8, false))
            {
                connectionString = sr.ReadToEnd();
            }
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddSingleton<IOrderDbContext, OrderDbContext>(s => new OrderDbContext(connectionString));
            return services;
        }
    }
}
