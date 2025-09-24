using IndianMusic.Infrastructure.Interfaces;
using IndianMusic.Infrastructure.Repositories;

namespace IndianMusic.WebApp.Extensions
{
    public static partial class ExtensionMethods
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<ISearchRepository, SearchRepository>();

            return services;
        }
    }
}
