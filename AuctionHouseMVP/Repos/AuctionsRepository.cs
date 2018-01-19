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


        public bool CheckIfAuctionEnded(string ID)
        {
            var auction = GetAuctionByID(ID);
            var date = auction.DateCreated.AddDays(auction.ExpiresIn);
            if (date > DateTime.Now)
            {
                auction.IsEnded = true;
                UpdateAuction(auction);
                Save();
                return true;
            }

            return false;
        }

        public bool CheckIfEndingPriceIsOk(BidsModel bid)
        {
            var auc = GetAuctionByID(bid.AuctionId);
            if (auc.EndingPrice < bid.Value)
            {
                auc.EndingPrice = bid.Value;
                UpdateAuction(auc);
                Save();
                return true;
            }

            return false;

        }

        public IEnumerable<AuctionModel> GetAuctionModelsBySingleCategory(string ID)
        {
            return context.Auctions.Where(x => x.CategoryId == ID);
        }

        public IEnumerable<AuctionModel> GetAuctionsByCatList(IEnumerable<CategoryModel> Categories)
        {
            List<string> lst = new List<string>();
            foreach (var item in Categories)
            {
                lst.Add(item.Id);
            }
            return GetAuctions().Where(x => lst.Contains(x.CategoryId));

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