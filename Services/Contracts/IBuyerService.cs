using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface IBuyerService
    {
        Task<IEnumerable<Buyer>> GetBuyer();
        Task<Buyer> GetBuyer(int id);
        Task<Buyer> PutBuyer(Buyer buyer);
        Task<Buyer> PatchBuyer(Buyer buyer);
    }
}