using IndianMusic.Infrastructure.Interfaces;
using IndianMusic.Infrastructure.Repositories;
using IndianMusic.Application;

namespace IndianMusic.WebApp.Extensions
{
    public static partial class ExtensionMethods
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IEmailSenderFromApp, EmailSenderFromApp>();

            return services;
        }
    }
}
