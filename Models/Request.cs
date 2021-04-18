using System;

namespace WebAppClient.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int DealerId { get; set; }
        public int BuyerId { get; set; }
        public int? CarId { get; set; }
        public DateTime DateBuy { get; set; }
    }
}