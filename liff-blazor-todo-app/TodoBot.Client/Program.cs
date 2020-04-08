using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LineDC.Liff;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TodoBot.Client.Srvices;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System;

namespace TodoBot.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine(args.Length);
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddBaseAddressHttpClient();
            AddTodoBotService(builder.Services);

            await builder.Build().RunAsync();
        }

        private static void AddTodoBotService(IServiceCollection services)
        {
            services.AddSingleton<ITodoClient>(provider =>
            {
                var appSettings = provider.GetRequiredService<IConfiguration>().Get<AppSettings>();
                var httpClient = provider.GetRequiredService<HttpClient>();
                if (string.IsNullOrEmpty(appSettings?.FunctionUrl))
                {
                    return new MockTodoClient();
                }
                return new TodoClient(
                    httpClient,
                    appSettings.FunctionUrl);
            });
            services.AddSingleton<ILiffClient>(provider =>
            {
                var appSettings = provider.GetRequiredService<IConfiguration>().Get<AppSettings>();
                return new LiffClient(appSettings.LiffId);
            });

        }
    }
}
