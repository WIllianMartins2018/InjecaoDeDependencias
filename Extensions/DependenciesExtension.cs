using DemoInjecaoDependencias.Repositories.Contracts;
using DemoInjecaoDependencias.Repositories;
using DemoInjecaoDependencias.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Data.SqlClient;
using DemoInjecaoDependencias.Services.Contracts;

namespace DemoInjecaoDependencias.Extensions
{
    public static class DependenciesExtension
    {
        public static void AddSqlConnection(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddScoped<SqlConnection>(x
                => new SqlConnection(connectionString));
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDeliveryFeeServices, DeliveryFeeService>();
        }
    }
}
