using System.Collections.Generic;
using AHWForm.View;

namespace AHWForm.Models
{
    public class AuctionBidsViewModel : IAuctionBidsViewModel
    {
        public AuctionBidsViewModel(IEnumerable<BidsModel> bids)
        {
            bidsViewModel = new List<AuctionBidViewModel>();
            foreach (BidsModel item in bids)
            {
                bidsViewModel.Add(new AuctionBidViewModel(item));
            }
        }

        public IList<AuctionBidViewModel> bidsViewModel { get; private set; }
    }
}