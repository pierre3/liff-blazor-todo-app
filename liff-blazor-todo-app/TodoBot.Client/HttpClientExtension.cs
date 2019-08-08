using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoBot.Shared;

namespace TodoBot.Client
{
    public static class HttpClientExtension
    {
        public static readonly string baseUrl = "https://mytaskbot.azurewebsites.net";
        public static async Task<IList<Todo>> GetTodoListAsync(this HttpClient httpClient, string accessToken, string userId)
        {
            var response = await SendAsync(
                httpClient,
                accessToken,
                HttpMethod.Get,
                $"{baseUrl}/api/{userId}/todoList");
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IList<Todo>>(body) ?? new List<Todo>();
        }

        public static async Task<Todo> GetTodoAsync(this HttpClient httpClient, string accessToken, string userId, string id)
        {
            var response = await SendAsync(
                httpClient,
                accessToken,
                HttpMethod.Get,
                $"{baseUrl}/api/{userId}/todoList/{id}");
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Todo>(body);
        }

        public static async Task UpdateTodoAsync(this HttpClient httpClient, string accessToken, string id, Todo todo)
        {
            var json = JsonConvert.SerializeObject(todo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await SendAsync(
                httpClient,
                accessToken,
                HttpMethod.Put,
                $"{baseUrl}/api/todoList/{id}",
                content);
        }

        public static async Task CreateTodoAsync(this HttpClient httpClient, string accessToken, Todo todo)
        {
            var json = JsonConvert.SerializeObject(todo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await SendAsync(
                httpClient,
                accessToken,
                HttpMethod.Post,
                $"{baseUrl}/api/todoList",
                content);
        }

        public static async Task DeleteTodoAsync(this HttpClient httpClient, string accessToken, string userId, string id)
        {
            await SendAsync(
                httpClient, 
                accessToken, 
                HttpMethod.Delete, 
                $"{baseUrl}/api/{userId}/todoList/{id}");
        }


        private static async Task<HttpResponseMessage> SendAsync(HttpClient httpClient, string accessToken, HttpMethod method, string url, HttpContent content = null)
        {
            var request = new HttpRequestMessage(method, url);
            request.Headers.Add(ApiServer.AccessTokenHeaderName, accessToken);
            request.Content = content;
            var response = await httpClient.SendAsync(request);
            return response.EnsureSuccessStatusCode();
        }
    }
}
