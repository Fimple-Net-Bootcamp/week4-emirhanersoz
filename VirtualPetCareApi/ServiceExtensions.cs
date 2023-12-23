using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Repositories;

namespace VirtualPetCareApi
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<ICache, RedisCache>();

            services.AddScoped<IUnitOfWork, UnitOfWorkRepo>();

            return services;
        }
    }
}
