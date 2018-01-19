using AHWForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHWForm.Repos
{
    public interface IBidsRepository
    {
        IEnumerable<BidsModel> GetBids();
        BidsModel GetBidByID(string ID);
        IEnumerable<BidsModel> GetBidsByUserID(string ID);
        IEnumerable<BidsModel> GetBidsByAuctionID(string ID);
        //FillOthers
        void InsertAuction(BidsModel bidsModel);
        void UpdateAuction(BidsModel bidsModel);
        BidsModel GetMaxBidOfAuction(string auctionId);
        void Save();
    }
}
