using AHWForm.Repos;
using LINQPad;
using Repositories;

namespace AHWForm.Models
{
    public class NewBidViewModel : IBidViewModel
    {
        private readonly AuctionsRepository auctionRepo;
        private readonly BidsRepository bidsRepo;

        public NewBidViewModel()
        {
            bidsRepo = RepositoryFactory.GetRepositoryInstance<BidsModel, BidsRepository>();
            auctionRepo = RepositoryFactory.GetRepositoryInstance<AuctionModel, AuctionsRepository>();
        }

        public bool Bid(BidsModel bidsModel, string ID)
        {
            //TODO
            var bid = bidsRepo.GetMaxBidOfAuction(bidsModel.AuctionId);
            var auction = auctionRepo.GetSingleElementByID(ID);

            if (!auctionRepo.CheckIfAuctionEnded(ID))
            {
                if (bid == null)
                {
                    auction.EndingPrice = bidsModel.Value;
                    bidsRepo.Insert(bidsModel);
                    bidsRepo.Save();
                    return true;
                }

                if (!auctionRepo.CheckIfEndingPriceIsOk(bidsModel)) return true;
                bidsRepo.Insert(bidsModel);
                bidsRepo.Save();
                return true;

            }

            return false;
        }

        public bool CheckAuction(string ID)
        {
            return auctionRepo.GetSingleElementByID(ID) != null;
        }

        public AuctionModel GetAuctionModel(string ID)
        {
            return auctionRepo.GetSingleElementByID(ID);
        }

        ~NewBidViewModel()
        {
            auctionRepo.Dispose();
            bidsRepo.Dispose();
        }
            
    }
}