using System.Collections.Generic;
using AHWForm.Models;

namespace AHWForm.View
{
    public interface IAuctionBidsViewModel:IMVPView
    {
        IList<AuctionBidViewModel> bidsViewModel { get; }
    }
}