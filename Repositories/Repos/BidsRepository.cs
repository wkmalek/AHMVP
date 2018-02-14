using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using System.Data.Entity;
using System.Xml;
using MoreLinq;
using Repositories;
using Repositories.Context;

namespace AHWForm.Repos
{
    public class BidsRepository : AbstractDbRepostiory<BidsModel>, IBidsRepository<BidsModel> 
    {
        public BidsModel GetMaxBidOfAuction(string Id)
        {
            Connect();
            var bids = GetBidsByAuctionID(Id);
            var output = bids.Any() ? bids.MaxBy(x => x.Value) : null;
            return output;
        }

        public IEnumerable<BidsModel> GetBidsByAuctionID(string ID)
        {
            Connect();
            var output = context.dbSet.Where(x => x.AuctionId == ID).ToList();
            return output;
        }

        public IEnumerable<BidsModel> GetBidsByUserID(string ID)
        {
            Connect();
            var output = context.dbSet.Where(x => x.AuctionId == ID).ToList();
            return output;
        }

        ~BidsRepository()
        {
            Dispose(false);
        }
    }
}