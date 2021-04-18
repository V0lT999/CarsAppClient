using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class RequestController : Controller
    {
        // GET
        private IRequestService RequestService { get; }
        private IBuyerService BuyerService { get; }
        private IDealerService DealerService { get; }
        private ICarService CarService { get; }
        
        public RequestController(IRequestService requestService, IBuyerService buyerService, IDealerService dealerService, ICarService carService)
        {
            RequestService = requestService;
            BuyerService = buyerService;
            DealerService = dealerService;
            CarService = carService;
        }

        public async Task<IActionResult> Requests()
        {
            
            return View(await this.RequestService.GetRequest());
        }

        [HttpGet]
        public async Task<IActionResult> AddRequest()
        {
            return View(new HelpObjects(await  this.BuyerService.GetBuyer(),
                await  this.DealerService.GetDealer(),
                await this.CarService.GetCar()));
        }
        [HttpPost]
        public async Task<IActionResult> Put(Request request)
        {
            await this.RequestService.PutRequest(request);
            return RedirectToAction("Requests");
        }
    }
}