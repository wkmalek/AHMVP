using System;
using AHWForm.Presenter;
using AHWForm.Repos;
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
                if (auctionRepo.CheckIfAuctionEnded(item.Id))
                {
                    item.IsEnded = true;
                    var maxBid = bidsRepo.GetMaxBidOfAuction(item.Id);
                    if (maxBid != null)
                        item.WinnerId = maxBid.UserId;
                    else
                        item.WinnerId = null;
                    auctionRepo.Update(item);
                }
            }
            auctionRepo.Save();
            AuctionListViewModel vm = new AuctionListViewModel(auctions, currency);
            return vm;
        }
    }
}