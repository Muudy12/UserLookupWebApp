using Serilog;

namespace UserLookupWebApp
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config.Build())
                .CreateLogger();

            try
            {
                Log.Information("Application Starting...");
                var host = CreateHostBuilder(args).Build();
                using IServiceScope scope = host.Services.CreateScope();
                scope.ServiceProvider.GetRequiredService<IProgram>().Run(args);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Fatal Error has occured.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<IProgram, Program>(); //Each connection has its own Singleton
                })
                .UseSerilog();
        }
    }
}
