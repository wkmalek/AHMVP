using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using System.Data.Entity;
using MoreLinq;

namespace AHWForm.Repos
{
    public class BidsRepository : IBidsRepository, IDisposable
    {
        private BidContext context;

        public BidsRepository(BidContext context)
        {
            this.context = context;
        }

        public BidsModel GetBidByID(string ID)
        {
            return context.Bids.Find(ID);
        }

        public IEnumerable<BidsModel> GetBids()
        {
            return context.Bids.ToList();
        }

        public BidsModel GetMaxBidOfAuction(string Id)
        {
            var bids = GetBidsByAuctionID(Id);
            if (bids.Count() > 0)
            {
                return bids.MaxBy(x => x.Value);
            }

            return null;
        }

        public IEnumerable<BidsModel> GetBidsByAuctionID(string ID)
        {
            return context.Bids.Where(x => x.AuctionId == ID).ToList();
        }

        public IEnumerable<BidsModel> GetBidsByUserID(string ID)
        {
            return context.Bids.Where(x => x.AuctionId == ID).ToList();
        }

        public void InsertAuction(BidsModel bidsModel)
        {
            context.Bids.Add(bidsModel);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateAuction(BidsModel bidsModel)
        {
            context.Entry(bidsModel).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}