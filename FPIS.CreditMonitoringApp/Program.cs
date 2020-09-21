using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace FPIS.CreditMonitoringApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SetupLogger();

            try
            {
                Log.Information("Starting host!");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, "Application startup failed! Unexpected error!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void SetupLogger()
        {
            var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true)
                    .Build();

            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .MinimumLevel.Verbose()
                    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                    .CreateLogger();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://192.168.1.126:5000/")
            .UseStartup<Startup>()
            .UseSerilog()
            .UseKestrel();
    }
}
