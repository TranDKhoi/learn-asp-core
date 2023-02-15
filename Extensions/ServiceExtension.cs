using LearnASP.Core.Contracts;
using LearnASP.Core.Repositories;

namespace LearnASP.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureRepository(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWork, UnitOfWork>();

    }
}
