using example.Models;
using example.Models.EntityModel.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace example.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigurarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ExampleDbContext>(opt =>
            {
                opt.UseSqlServer(connection, x => x.CommandTimeout(120));
                opt.EnableSensitiveDataLogging(true);
            });

            services.AddScoped<Produto>();

            return services;

        }
    }
}
