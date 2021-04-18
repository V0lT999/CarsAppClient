using System.Collections.Generic;

namespace WebAppClient.Models
{
    public class HelpObjects
    {
        
        public IEnumerable<Buyer> Buyers;
        public IEnumerable<Dealer> Dealers;
        public IEnumerable<Car> Cars;

        public HelpObjects(IEnumerable<Buyer> buyers, IEnumerable<Dealer> dealers, IEnumerable<Car> car)
        {
            Buyers = buyers;
            Dealers = dealers;
            Cars = car;
        }
    }
}