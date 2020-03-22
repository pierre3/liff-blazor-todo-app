using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LineDC.Liff;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TodoBot.Client.Srvices;
using System.Linq;
using System.Net.Http;

namespace TodoBot.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddBaseAddressHttpClient();
#if DEBUG
            builder.Services.AddSingleton<ITodoClient>(new MockTodoClient());
            var liffId = "1653926279-Q76O2r4M";
#else
            builder.Services.AddSingleton<ITodoClient>(
                provider => new TodoClient(provider.GetService<HttpClient>(), 
                "https://liff-todo-func.azurewebsites.net"));
            var liffId = "1653926279-b1GD68mM";
#endif
            builder.Services.AddSingleton<ILiffClient>(new LiffClient(liffId));

            var host = builder.Build();
            await host.RunAsync();
        }
    }
}
