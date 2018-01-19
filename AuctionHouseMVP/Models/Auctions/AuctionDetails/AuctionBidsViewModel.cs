using AHWForm.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHWForm.Models
{
    public class AuctionBidsViewModel : IAuctionBidsViewModel
    {
        public IList<AuctionBidViewModel> bidsViewModel {get;set;}
        public AuctionBidsViewModel(IEnumerable<BidsModel> bids)
        {
            bidsViewModel = new List<AuctionBidViewModel>();
            foreach(BidsModel item in bids)
            {
                bidsViewModel.Add(new AuctionBidViewModel(item));
            }
            
        }
    }
}