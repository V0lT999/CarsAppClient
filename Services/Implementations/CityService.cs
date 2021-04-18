using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class CityService:ICityService
    {
        private HttpClient HttpClient { get; }
        
        public CityService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<City>> GetCity()
        {
            using var response = await this.HttpClient.GetAsync("api/city");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<City>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<City> GetCity(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/city/" + id);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<City>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<City> PutCity(City city)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(city), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/city",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<City>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<City> PatchCity(City city)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(city), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/city",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<City>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}