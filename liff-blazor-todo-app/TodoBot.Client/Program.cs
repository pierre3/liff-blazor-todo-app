using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LineDC.Liff;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TodoBot.Client.Srvices;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace TodoBot.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var appSettings = GetAppSettings();
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddBaseAddressHttpClient();

            AddTodoBotService(builder.Services, appSettings);

            await builder.Build().RunAsync();
        }

        private static void AddTodoBotService(IServiceCollection services, AppSettings appSettings)
        {
#if DEBUG
            services.AddSingleton<ITodoClient>(new MockTodoClient());
            services.AddSingleton<ILiffClient>(new LiffClient(appSettings.LiffIdForDebug));
#else
            services.AddSingleton<ITodoClient>(
                            provider => new TodoClient(
                                provider.GetService<HttpClient>(),
                                appSettings.FunctionSettings));
            services.AddSingleton<ILiffClient>(new LiffClient(appSettings.LiffId));
#endif
        }

        private static AppSettings GetAppSettings()
        {
            var stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("TodoBot.Client.appsettings.json");
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
            return config.GetSection("AppSettings").Get<AppSettings>();
        }
    }
}
