using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class DealerService: IDealerService
    {
        private HttpClient HttpClient { get; }
        
        public DealerService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Dealer>> GetDealer()
        {
            using var response = await this.HttpClient.GetAsync("api/dealer");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Dealer>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Dealer> GetDealer(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/dealer/" + id);
            
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Dealer>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Dealer> PutDealer(Dealer dealer)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(dealer), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/dealer",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Dealer>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Dealer> PatchDealer(Dealer dealer)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(dealer), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/dealer",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Dealer>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}