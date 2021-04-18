using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class BuyerController : Controller
    {
        private IBuyerService BuyerService { get; }
        private ICityService CityService { get; }
        public BuyerController(IBuyerService buyerService, ICityService cityService)
        {
            BuyerService = buyerService;
            CityService = cityService;
        }
        public async  Task<IActionResult> List()
        {
            return View(await this.BuyerService.GetBuyer());
        }
      
        public async Task<IActionResult> AddBuyer()
        {
            return View(await  this.CityService.GetCity());
        }

        [HttpPost]
        public async Task<IActionResult> Put(Buyer buyer)
        {
            System.Console.WriteLine(" fdfsdf"  + buyer.CityId);
            await this.BuyerService.PutBuyer(buyer);
            return RedirectToAction("List");
        }
    }
}