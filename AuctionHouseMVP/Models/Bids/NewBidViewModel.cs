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
            BidsModel bid = bidsRepo.GetMaxBidOfAuction(bidsModel.AuctionId);
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

                if (auctionRepo.CheckIfEndingPriceIsOk(bidsModel))
                {
                    bidsRepo.Insert(bidsModel);
                    bidsRepo.Save();
                    return true;
                }

                return true;
            }

            return false;
        }

        public bool CheckAuction(string ID)
        {
            if (auctionRepo.GetSingleElementByID(ID) == null)
                return false;
            return true;
        }

        public AuctionModel GetAuctionModel(string ID)
        {
            return auctionRepo.GetSingleElementByID(ID);
        }
            
    }
}