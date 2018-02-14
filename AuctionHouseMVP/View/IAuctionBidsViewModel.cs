using System.Collections.Generic;
using AHWForm.Models;

namespace AHWForm.View
{
    public interface IAuctionBidsViewModel
    {
        IList<AuctionBidViewModel> bidsViewModel { get; }
    }
}