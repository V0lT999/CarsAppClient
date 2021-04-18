using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class CarService:ICarService
    {
        private HttpClient HttpClient { get; }
        
        public CarService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Car>> GetCar()
        {
            using var response = await this.HttpClient.GetAsync("api/car");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Car>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Car> GetCar(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/car/" + id);
            
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Car>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Car> PutCar(Car car)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(car), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/car",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Car>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Car> PatchCar(Car car)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(car), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/car",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Car>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}