using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Repos;
using Repositories;

namespace AHWForm.Models
{
    public class NewBidViewModel : IBidViewModel
    {
        
        public decimal Value { get; set; }
        private BidsRepository bidsRepo;
        private AuctionsRepository auctionRepo;
        public NewBidViewModel()
        {
            bidsRepo = RepositoryFactory.GetRepositoryInstance<BidsModel, BidsRepository>();
            auctionRepo = RepositoryFactory.GetRepositoryInstance<AuctionModel, AuctionsRepository>();
        }

        public bool Bid(BidsModel bidsModel, string ID)
        {
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
                else
                {
                    if (auctionRepo.CheckIfEndingPriceIsOk(bidsModel))
                    {
                        bidsRepo.Insert(bidsModel);
                        bidsRepo.Save();
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return false;         
        }

        
        
    }
}