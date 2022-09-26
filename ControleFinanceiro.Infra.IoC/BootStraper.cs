using ControleFinanceiro.Application.Mappings;
using ControleFinanceiro.Application.Services;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using ControleFinanceiro.Infra.Data.Context;
using ControleFinanceiro.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ControleFinanceiro.Infra.IoC
{
    public static class BootStraper
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterContext(services, configuration);
            RegisterContextSwagger(services, configuration);
            RegisterAutoMapper(services, configuration);
            ResgisterRepositories(services, configuration);
            ResgisterServices(services, configuration);

            return services;
        }

        private static void RegisterAutoMapper(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        }

        private static void ResgisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IVariedCostService, VariedCostService>();
            services.AddScoped<IFixedCostService, FixedCostService>();
            services.AddScoped<IFixedCostCategoryService, FixedCostCategoryService>();
        }

        private static void ResgisterRepositories(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IVariedCostRepository, VariedCostRepository>();
            services.AddScoped<IFixedCostRepository, FixedCostRepository>();
            services.AddScoped<IFixedCostCategoryRepository, FixedCostCategoryRepository>();
        }

        private static void RegisterContext(IServiceCollection services, IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        private static void RegisterContextSwagger(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControleFinanceiro.Api", Version = "v1" });
                c.EnableAnnotations();
            });
        }
    }
}
