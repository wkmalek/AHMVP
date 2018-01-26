using System.Collections.Generic;
using AHWForm.Repos;

namespace AHWForm.Models
{
    public class AuctionListViewModel
    {
        public AuctionListViewModel(IEnumerable<AuctionModel> auctionModels, string currency)
        {
            mainList = new List<AuctionListSingleElemVM>();
            foreach (var item in auctionModels)
            {
                mainList.Add(new AuctionListSingleElemVM(item, currency, new CurrencyExchangeRepository()));
            }
        }

        public List<AuctionListSingleElemVM> mainList { get; }
    }
}