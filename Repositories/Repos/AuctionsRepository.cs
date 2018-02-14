using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using System.Data;
using System.Data.Entity;
using Repositories;
using Repositories.Context;

namespace AHWForm.Repos
{
    public class AuctionsRepository : AbstractDbRepostiory<AuctionModel>, IAuctionsRepository<AuctionModel>
    {
        

        public IEnumerable<AuctionModel> GetAuctionByUserID(string ID)
        {
            Connect();
            var output = context.dbSet.Where(x => x.WinnerId == ID).ToList();
            context.Dispose();
            return output;
        }

        public bool CheckIfAuctionEnded(string ID)
        {
            var auction = GetSingleElementByID(ID);
            var date = auction.DateCreated.AddDays(auction.ExpiresIn);
            var comp = DateTime.Compare(date, DateTime.Now);
            if (comp <= 0)
            {
                auction.IsEnded = true;
                Update(auction);
                Save();
                return true;
            }
            return false;
        }

        public bool CheckIfEndingPriceIsOk(BidsModel bid)
        {
            if (bid == null)
                return true;
            var auc = GetSingleElementByID(bid.AuctionId);
            if (auc.EndingPrice < bid.Value)
            {
                auc.EndingPrice = bid.Value;
                Update(auc);
                Save();
                return true;
            }
            return false;
        }

        public IEnumerable<AuctionModel> GetAuctionModelsBySingleCategory(string ID)
        {
            Connect();
            var output = context.dbSet.Where(x => x.CategoryId == ID);
            context.Dispose();
            return output; 
        }

        public IEnumerable<AuctionModel> GetAuctionsByCatList(IEnumerable<CategoryModel> Categories)
        {
            Connect();
            List<string> lst = new List<string>();
            foreach (var item in Categories)
            {
                lst.Add(item.Id);
            }
            var output = GetAllElements().Where(x => lst.Contains(x.CategoryId));
            context.Dispose();
            return output;
        }

        ~AuctionsRepository()
        {
            Dispose(false);
        }
    }
}