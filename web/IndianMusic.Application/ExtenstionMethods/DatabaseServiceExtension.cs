using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace IndianMusic.Application.ExtenstionMethods
{
    public static class DatabaseServiceExtension
    {
        //public static IServiceCollection AddDatabaseConnections(this IServiceCollection services)
        //{
        //    //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        //    //services.AddDbContext<ApplicationDbContext>(options =>
        //    //    options.UseSqlServer(connectionString));


        //    //// Register repositories here
        //    ////services.AddScoped<IArtistRepository, ArtistRepository>();

        //    //// If you want to add generic repository too
        //    ////services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        //    //return services;
        //}
    }
}
