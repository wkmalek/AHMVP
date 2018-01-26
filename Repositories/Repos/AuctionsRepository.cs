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
    public class AuctionsRepository : AbstractRepostiory<AuctionModel>, IAuctionsRepository<AuctionModel>
    {
        public AuctionsRepository()
        {
            context = new GenericContextFactory<AuctionModel>("AuctionContext");
        }

        public IEnumerable<AuctionModel> GetAuctionByUserID(string ID)
        {
            return context.dbSet.Where(x => x.WinnerId == ID).ToList();
        }

        public bool CheckIfAuctionEnded(string ID)
        {
            var auction = GetSingleElementByID(ID);
            var date = auction.DateCreated.AddDays(auction.ExpiresIn);
            var comp = DateTime.Compare(date, DateTime.Now);
            if (comp <= 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckIfEndingPriceIsOk(BidsModel bid)
        {
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
            return context.dbSet.Where(x => x.CategoryId == ID);
        }

        public IEnumerable<AuctionModel> GetAuctionsByCatList(IEnumerable<CategoryModel> Categories)
        {
            List<string> lst = new List<string>();
            foreach (var item in Categories)
            {
                lst.Add(item.Id);
            }
            return GetAllElements().Where(x => lst.Contains(x.CategoryId));
        }
    }
}