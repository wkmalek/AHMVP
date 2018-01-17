using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using AHWForm.Repos;

namespace AHWForm.Models
{
    public class AuctionModel 
    {
        [ScaffoldColumn(false)]        
        public string Id { get; set; }
        [ScaffoldColumn(false)]
        public string CategoryId { get; set; }
        public string Title { get; set; }
        public decimal StartPrice { get; set; }
        public decimal EndingPrice { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; }
        [ScaffoldColumn(false)]
        public int ExpiresIn { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [ScaffoldColumn(false)]
        public bool IsEnded { get; set; }
        //public List<Bid> Bids { get; set; }
        [ScaffoldColumn(false)]
        public string CreatorId { get; set; } 
        [ScaffoldColumn(false)]
        public string WinnerId { get; set; }
        public string LongDescription { get; set; }
        //public string Currency { get; set; }
    }

    

    public class AuctionContext : DbContext
    {
        public DbSet<AuctionModel> Auctions { get; set; }

        public List<AuctionModel> ReturnSelectedAuctions(string id, paramTypeForCategory type)
        {
            switch (type)
            {
                case paramTypeForCategory.byId:
                    return Auctions.Where(x => x.Id == id).ToList();
                case paramTypeForCategory.byUserId:
                    return Auctions.Where(x => x.CreatorId == id).ToList();
                case paramTypeForCategory.bySelectedCategory:
                    return Auctions.Where(x => x.CategoryId == id).ToList();
                //case paramType.bySelectedCategoriesWithChildrens:

                //    break;
                default:
                    return Auctions.Where(x => x.Id == id).ToList();
            }
        }

        public AuctionModel ReturnSelectedAuction(string id, paramTypeForCategory type)
        {
            switch (type)
            {
                case paramTypeForCategory.byId:
                    return Auctions.Where(x => x.Id == id).FirstOrDefault();
                default:
                    return Auctions.Where(x => x.Id == id).FirstOrDefault();
            }
        }
    }
}