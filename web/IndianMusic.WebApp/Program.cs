using IndianMusic.WebApp.Extensions;
using Serilog;
using IndianMusic.WebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                Application.AppLogger.AddLoggerConfiguration();
                builder.Host.UseSerilog(); // Plug Serilog into ASP.NET Core

                builder.Services.AddDatabaseConnections(builder);
                builder.Services.AddDatabaseDeveloperPageExceptionFilter();
                builder.Services.AddApplicationIdentity();
                builder.Services.AddMultiLanguageFacility(); // Add Controllers With Views
                builder.Services.AddRazorPages();
                builder.Services.AddMemoryCache();
                builder.Services.ConfigureCookie();
                builder.Services.AddApplicationAuthentications(builder); // builder.Services.AddAuthentication();
                builder.Services.AddAuthorization();
                builder.Services.AddApplicationTranslation(builder);
                builder.Services.AddRepositories();
                builder.Services.AddApplicationServices();

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
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
           
        }
    }

    // Required for Resource object
    public class Labels { }
    public class MenuItems { }
}
