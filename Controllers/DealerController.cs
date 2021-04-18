using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class DealerController : Controller
    {
        private IDealerService DealerService { get; }
        
        public DealerController(IDealerService dealerService)
        {
            DealerService = dealerService;
        }
        public async Task<IActionResult> List()
        {
            return View(await this.DealerService.GetDealer());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(await this.DealerService.GetDealer());
        }
        [HttpPost]
        public async Task<IActionResult> Put(Dealer dealer)
        {
            await this.DealerService.PutDealer(dealer);
            return RedirectToAction("List");
        }
    }
}