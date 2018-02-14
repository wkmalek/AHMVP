using System.Collections.Generic;
using AHWForm.View;
using AHWForm.Repos;

namespace AHWForm.Models
{
    public class AuctionBidsViewModel : IAuctionBidsViewModel
    {
        public AuctionBidsViewModel(IEnumerable<BidsModel> bids, string baseCurrency, string targetCurrency, ICurrencyExchangeRepository currencyExchangeRepository)
        {
            bidsViewModel = new List<AuctionBidViewModel>();
            foreach (var item in bids)
            {
                //TODO currency
                var endingPrice =
                    currencyExchangeRepository.GetValueInAnotherCurrency(item.Value, baseCurrency,
                        targetCurrency);
                if (endingPrice != null)
                {
                    item.Value = (decimal)endingPrice;
                }
                bidsViewModel.Add(new AuctionBidViewModel(item));
            }
        }

        public IList<AuctionBidViewModel> bidsViewModel { get; private set; }
    }
}