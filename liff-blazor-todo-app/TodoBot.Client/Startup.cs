using LineDC.Liff;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using TodoBot.Client.Srvices;

namespace TodoBot.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<ILiffClient, LiffClient>();
            //services.AddSingleton<ITodoBotClient, TodoBotClient>(provider =>
            //    new TodoBotClient(provider.GetService<HttpClient>(), "https://mytaskbot.azurewebsites.net"));

            services.AddSingleton<ILiffClient, MockLiffClient>();
            services.AddSingleton<ITodoClient, MockTodoClient>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
