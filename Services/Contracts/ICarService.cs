using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetCar();
        Task<Car> GetCar(int id);
        Task<Car> PutCar(Car car);
        Task<Car> PatchCar(Car car);
    }
}