using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface IRequestService
    {
        Task<IEnumerable<Request>> GetRequest();
        Task<Request> GetRequest(int id);
        Task<Request> PutRequest(Request request);
        Task<Request> PatchRequest(Request request);
    }
}