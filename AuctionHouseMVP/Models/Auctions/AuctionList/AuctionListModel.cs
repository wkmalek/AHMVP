using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Presenter;
using AHWForm.Repos;

namespace AHWForm.Models
{
    public class AuctionListModel:IAuctionListModel
    {
        private IAuctionsRepository auctionRepo { get; set; }
        private IBidsRepository bidsRepo { get; set; }
        private ICategoryRepository catRepo { get; set; }

        public AuctionListModel(IAuctionsRepository auctionRepo, IBidsRepository bidsRepo, ICategoryRepository catRepo)
        {
            this.auctionRepo = auctionRepo;
            this.bidsRepo = bidsRepo;
            this.catRepo = catRepo;
        }

        public AuctionListViewModel LoadAuctions(string ID)
        {
            var cats = catRepo.GetCategoriesWithChilds(ID);
            var auctions = auctionRepo.GetAuctionsByCatList(cats);
            AuctionListViewModel vm = new AuctionListViewModel(auctions);
            return vm;
        }
    }
}