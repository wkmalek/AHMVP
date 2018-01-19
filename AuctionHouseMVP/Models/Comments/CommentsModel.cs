using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AHWForm.Models
{
     public class CommentsModel: ICommentsModel
     {
        [ScaffoldColumn(false)]
        public string Id { get; set; }
        [ScaffoldColumn(false)]
        public string AuctionId {get;set;}
        [ScaffoldColumn(false)]
        public string BuyerId { get; set; }
        [ScaffoldColumn(false)]
        public string SellerId { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
     }
    public class CommentsView
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }
        public string AuctionUrl { get; set; }
        public string AuctionTitle { get; set; }
        public string BuyerUrl { get; set; }
        public string BuyerName { get; set; }
        public string SellerName { get; set; }
        public string SellerUrl { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
    }

    public class CommentsContext : DbContext
     {
        public DbSet<CommentsModel> Comment { get; set; }
        public DbSet<AuctionModel> Auctions { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<BidsModel> Bids { get; set; }
    }
}