using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class BuyerService:IBuyerService
    {
        private HttpClient HttpClient { get; }
        
        public BuyerService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Buyer>> GetBuyer()
        {
            using var response = await this.HttpClient.GetAsync("api/buyer");
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Buyer>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Buyer> GetBuyer(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/buyer/" + id);
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Buyer>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Buyer> PutBuyer(Buyer buyer)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(buyer), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/buyer",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Buyer>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Buyer> PatchBuyer(Buyer buyer)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(buyer), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/buyer",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Buyer>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}