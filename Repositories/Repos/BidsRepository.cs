using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using System.Data.Entity;
using MoreLinq;
using Repositories;
using Repositories.Context;

namespace AHWForm.Repos
{
    public class BidsRepository : AbstractRepostiory<BidsModel>, IBidsRepository<BidsModel> 
    {

        public BidsRepository()
        {
            context = new GenericContextFactory<BidsModel>("BidContext");
        }

        public BidsModel GetMaxBidOfAuction(string Id)
        {
            var bids = GetBidsByAuctionID(Id);
            return bids.Any() ? bids.MaxBy(x => x.Value) : null;
        }

        public IEnumerable<BidsModel> GetBidsByAuctionID(string ID)
        {
            return context.dbSet.Where(x => x.AuctionId == ID).ToList();
        }

        public IEnumerable<BidsModel> GetBidsByUserID(string ID)
        {
            return context.dbSet.Where(x => x.AuctionId == ID).ToList();
        }

        ~BidsRepository()
        {
            Dispose(false);
        }
    }
}