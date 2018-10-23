using Drm.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Drm.WebApi
{
    public class Program
  {
    public static void Main(string[] args)
    {
      var host = BuildWebHost(args);

      SeedingDb(host);

      host.Run();
    }

    private static void SeedingDb(IWebHost host)
    {
      var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

      using(var scope = scopeFactory.CreateScope())
      {
        var seeder = scope.ServiceProvider.GetService<DRMSeeder>();

        seeder.SeedAsync().Wait();
      }

    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(SetupConfiguration)
            .UseStartup<Startup>();

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
              .ConfigureAppConfiguration(SetupConfiguration)
              .UseStartup<Startup>()
              .Build();

    private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
    {
      // remove default
      builder.Sources.Clear();

      builder.AddJsonFile("config.json", false, true)
             .AddEnvironmentVariables();


    }
  }
}
