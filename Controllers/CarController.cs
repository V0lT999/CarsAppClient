using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class CarController:Controller
    {
        private ICarService CarService { get; }
        
        public CarController(ICarService carService)
        {
            CarService = carService;
        }
        public async Task<IActionResult> ListCars()
        {
            return View(await this.CarService.GetCar());
        }
        public async Task<IActionResult> InfoCar(int id)
        {
            return View(await this.CarService.GetCar(id));
        }
        
        public async Task<IActionResult> AddCar()
        {
            return View(await this.CarService.GetCar());
        }
        [HttpPost]
        public async Task<IActionResult> Put(Car car)
        {
            await this.CarService.PutCar(car);
            return RedirectToAction("ListCars");
        }
    }
}