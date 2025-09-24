using IndianMusic.WebApp.Data;
using IndianMusic.WebApp.Extensions;
using IndianMusic.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDatabaseConnections(builder);
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddApplicationIdentity();
            //builder.Services.AddControllersWithViews();
            builder.Services.AddMultiLanguageFacility();
            //builder.Services.AddControllersWithViews().AddViewLocalization().AddDataAnnotationsLocalization();
            builder.Services.AddRazorPages();
            builder.Services.AddMemoryCache();
            builder.Services.ConfigureCookie();
            builder.Services.AddApplicationAuthentications(builder); // builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
            builder.Services.AddApplicationTranslation(builder);
            builder.Services.AddRepositories();

            var app = builder.Build();
            app.UseLocalization();
            app.IsDevelopmentOrProduction();
            app.SeedUserAndRoles();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapAppRoutes();
            app.Run();
        }
    }

    // Required for Resource object
    public class Labels { }
    public class MenuItems { }
}
