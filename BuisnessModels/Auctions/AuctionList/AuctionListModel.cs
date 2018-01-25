using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Presenter;
using AHWForm.Repos;
using Repositories;

namespace AHWForm.Models
{
    public class AuctionListModel:IAuctionListModel
    {
        private IAuctionsRepository<AuctionModel> auctionRepo { get; set; }
        private IBidsRepository<BidsModel> bidsRepo { get; set; }
        private ICategoryRepository<CategoryModel> catRepo { get; set; }

        public AuctionListModel()
        {
            this.auctionRepo = RepositoryFactory.GetRepositoryInstance<AuctionModel, AuctionsRepository>();
            this.bidsRepo = RepositoryFactory.GetRepositoryInstance<BidsModel, BidsRepository>();
            this.catRepo = RepositoryFactory.GetRepositoryInstance<CategoryModel, CategoryRepository>();
        }

        public AuctionListViewModel LoadAuctions(string ID, string currency)
        {
            var cats = catRepo.GetCategoriesWithChilds(ID);
            var auctions = auctionRepo.GetAuctionsByCatList(cats);
            AuctionListViewModel vm = new AuctionListViewModel(auctions, currency);
            return vm;
        }
    }
}