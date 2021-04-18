using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class CityController : Controller
    {
        // GET
        private ICityService CityService { get; }
        
        public CityController(ICityService cityService)
        {
            CityService = cityService;
        }
        public async Task<IActionResult> ListCities()
        {
            return View(await this.CityService.GetCity());
        }

      
        [HttpPost]
        public async Task<IActionResult> Put(City city)
        {
            await this.CityService.PutCity(city);
            //Console.Out.WriteLine(city);
            return RedirectToAction("ListCities");
        }

    }
}