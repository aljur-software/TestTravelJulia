using Core.Interfaces;
using DataLayerEF.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayerEF.DI
{
    public static class DataLayerDI
    {
        public static void AddDataLayer(this IServiceCollection services, string connectionString)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<AppEFContext>(options =>
                options.UseNpgsql(connectionString));
            services.AddScoped<IBaseRepository<Agency>, AgencyRepository>();
            services.AddScoped<IBaseRepository<Agent>, AgentRepository>();            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
