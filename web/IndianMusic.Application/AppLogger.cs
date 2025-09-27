using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianMusic.Application
{
    public static class AppLogger
    {
        public static void AddLoggerConfiguration()
        {

            // Configure Serilog
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Fatal) // Ignore ASP.NET logs
            //    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", Serilog.Events.LogEventLevel.Fatal) // Ignore EF Core
            //    .MinimumLevel.Debug() // Keep your own logs
            //    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();

            //Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .Enrich.FromLogContext()
                .CreateLogger();

            //Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Debug()
            //.WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            //.CreateLogger();
        }
    }
}
