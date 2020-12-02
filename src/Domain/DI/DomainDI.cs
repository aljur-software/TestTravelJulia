using Domain.Interfaces;
using Domain.MainLogicServices;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.DI
{
    public static class DomainDI
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddTransient<IAgencyService, AgencyService>();
        }
    }
}
