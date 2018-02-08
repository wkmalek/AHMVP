using AHWForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHWForm.Repos
{
    public interface IBidsRepository<T>: IRepository<T> where T:class
    {
        IEnumerable<T> GetBidsByUserID(string ID);
        IEnumerable<T> GetBidsByAuctionID(string ID);
        T GetMaxBidOfAuction(string auctionId);

    }
}
