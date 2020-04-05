using LineDC.Liff;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace TodoBot.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("TodoBot.Client.appsettings.json");
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
            var liffId = config.GetValue<string>("LiffId");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddSingleton<ILiffClient>(new LiffClient(liffId));
            var host = builder.Build();
            await host.RunAsync();
        }

    }
}
