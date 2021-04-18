using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface IDealerService
    {
        Task<IEnumerable<Dealer>> GetDealer();
        Task<Dealer> GetDealer(int id);
        Task<Dealer> PutDealer(Dealer dealer);
        Task<Dealer> PatchDealer(Dealer dealer);
    }
}