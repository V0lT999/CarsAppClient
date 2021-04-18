using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCity();
        Task<City> GetCity(int id);
        Task<City> PutCity(City city);
        Task<City> PatchCity(City city);
    }
}