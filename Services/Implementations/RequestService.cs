using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class RequestService:IRequestService
    {
        private HttpClient HttpClient { get; }
        
        public RequestService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Request>> GetRequest()
        {
            using var response = await this.HttpClient.GetAsync("api/request");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Request>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Request> GetRequest(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/request/" + id);
            
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Request>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Request> PutRequest(Request request)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/request",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Request>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Request> PatchRequest(Request request)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/request",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Request>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}