using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenNLP.Configurations;
using System.Threading.Tasks;

namespace Trainer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);
            await hostBuilder.RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .AddEnvironmentVariables(prefix: "OPENNLP")
                        .AddJsonFile("appsettings.json", optional: true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                        .AddCommandLine(args);
                })
                .ConfigureServices(services =>
                {
                    services.AddOptions<OpenNLPSettings>().Configure(o => o.GetDefaultSettings());
                    services.AddHostedService<TrainerService>();
                });
    }
}
