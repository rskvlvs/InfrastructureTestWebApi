using Microsoft.Extensions.DependencyInjection;
using StatisticsLogic.Repositories;
using StatisticsLogic.Repositories.Interfaces;

namespace StatisticsLogic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddLogicServices(this IServiceCollection services)
        {
            services.AddSingleton<IErrorRepository, ErrorRepository>();
        }
    }
}
