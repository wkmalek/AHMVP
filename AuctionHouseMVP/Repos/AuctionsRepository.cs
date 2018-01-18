using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using System.Data;
using System.Data.Entity;

namespace AHWForm.Repos
{
    public class AuctionsRepository : IAuctionsRepository, IDisposable
    {
        private AuctionContext context;

        public AuctionsRepository(AuctionContext context)
        {
            this.context = context;
        }

        public AuctionModel GetAuctionByID(string ID)
        {
            return context.Auctions.Find(ID);
        }

        public IEnumerable<AuctionModel> GetAuctionModelsBySingleCategory(string ID)
        {
            return context.Auctions.Where(x => x.CategoryId == ID);
        }

        public IEnumerable<AuctionModel> GetAuctionsByCatList(IEnumerable<CategoryModel> Categories)
        {
            
            return GetAuctions().Where(x => x.CategoryId.Contains(x.CategoryId));

        }

        public IEnumerable<AuctionModel> GetAuctions()
        {
            return context.Auctions.ToList();
        }

        public void InsertAuction(AuctionModel auctionModel)
        {
            context.Auctions.Add(auctionModel);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateAuction(AuctionModel auction)
        {
            context.Entry(auction).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
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