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
        public class AuctionContext : DbContext
        {
            public AuctionContext(): base("name=AuctionContext")
            {

            }
            public DbSet<AuctionModel> AuctionModel { get; set; }
        }

        private AuctionContext context;

        public AuctionsRepository()
        {
            context = new AuctionContext();
        }

        public AuctionModel GetAuctionByID(string ID)
        {
            return context.AuctionModel.Find(ID);
        }

        

        public IEnumerable<AuctionModel> GetAuctionByUserID(string ID)
        {
            return context.AuctionModel.Where(x => x.WinnerId == ID).ToList();
        }

        public bool CheckIfAuctionEnded(string ID)
        {
            var auction = GetAuctionByID(ID);
            var date = auction.DateCreated.AddDays(auction.ExpiresIn);
            var comp = DateTime.Compare(date, DateTime.Now);
            if (comp>0)
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
            return context.AuctionModel.Where(x => x.CategoryId == ID);
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
            return context.AuctionModel.ToList();
        }

        public void InsertAuction(AuctionModel auctionModel)
        {
            context.AuctionModel.Add(auctionModel);
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