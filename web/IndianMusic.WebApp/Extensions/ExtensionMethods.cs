using IndianMusic.Application.Services;
using IndianMusic.WebApp.Data;
using IndianMusic.WebApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using IndianMusic.Domain.Models;

namespace IndianMusic.WebApp.Extensions
{
    public static partial class ExtensionMethods
    {
        public static IServiceCollection AddDatabaseConnections(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<IndianMusicDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.SignIn.RequireConfirmedEmail = true; //This tells Identity to generate a confirmation token and prevent unconfirmed users from logging in. The default ASP.NET Core Identity scaffolded pages handle the token generation and link creation, but you need to provide the actual email sending mechanism.
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddApplicationAuthentications(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
            })
            .AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = builder.Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
            }); 

            return services;
        }

        public static IServiceCollection AddApplicationTranslation(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var apiKey = builder.Configuration["GoogleTranslate:ApiKey"];
            services.AddSingleton(new TranslationService(apiKey));
            return services;
        }

        

        public static IServiceCollection AddMultiLanguageFacility(this IServiceCollection services)
        {
            // Support for multi language support / Localisation
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            // Add MVC + Razor Pages
            services
                .AddControllersWithViews()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();

            return services;
        }

        public static IServiceCollection ConfigureCookie(this IServiceCollection services)
        {
            // Configure cookie paths
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            return services;
        }


        public static WebApplication MapAppRoutes(this WebApplication app)
        {
            // Area routes first
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            // Default route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }

        public static WebApplication SeedUserAndRoles(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                IdentitySeeder.SeedRolesAndAdminAsync(serviceProvider).GetAwaiter().GetResult();
            }
            return app;
        }

        public static WebApplication IsDevelopmentOrProduction(this WebApplication app)
        {
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseMigrationsEndPoint();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}"); // Handles 404, 500 etc.

            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseExceptionHandler("/Home/Error");
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}"); // Handles 404, 500 etc.
            app.UseHsts();
            return app;
        }

        public static WebApplication UseLocalization(this WebApplication app)
        {
            // Define supported cultures
            var supportedCultures = new[]
            {
                new CultureInfo("en"),  // English
                new CultureInfo("hi"),  // Hindi
                new CultureInfo("or")   // Odia
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            return app;
        }
    }
}
