using System;
using AHWForm.Presenter;
using AHWForm.Repos;
using LINQPad.FSharpExtensions;
using Repositories;

namespace AHWForm.Models
{
    public class AuctionListModel : IAuctionListModel
    {
        public AuctionListModel()
        {
            auctionRepo = RepositoryFactory.GetRepositoryInstance<AuctionModel, AuctionsRepository>();
            catRepo = RepositoryFactory.GetRepositoryInstance<CategoryModel, CategoryRepository>();
            bidsRepo = RepositoryFactory.GetRepositoryInstance<BidsModel, BidsRepository>();
        }

        private IAuctionsRepository<AuctionModel> auctionRepo { get; }
        private ICategoryRepository<CategoryModel> catRepo { get; }
        private IBidsRepository<BidsModel> bidsRepo { get; }

        public AuctionListViewModel LoadAuctions(string ID, string currency)
        {
            var cats = catRepo.GetCategoriesWithChilds(ID);
            var auctions = auctionRepo.GetAuctionsByCatList(cats);
            if (auctions == null) throw new ArgumentNullException(nameof(auctions));
            foreach (var item in auctions)
            {
                if (!auctionRepo.CheckIfAuctionEnded(item.Id)) continue;
                item.IsEnded = true;
                var maxBid = bidsRepo.GetMaxBidOfAuction(item.Id);
                item.WinnerId = maxBid?.UserId;
                auctionRepo.Update(item);
            }
            auctionRepo.Save();
            var vm = new AuctionListViewModel(auctions, currency);
            return vm;
        }

        ~AuctionListModel()
        {
            auctionRepo.Dispose();
            bidsRepo.Dispose();
            catRepo.Dispose();
        }
    }
}