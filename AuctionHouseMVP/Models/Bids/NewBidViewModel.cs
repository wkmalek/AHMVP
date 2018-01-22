using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Repos;

namespace AHWForm.Models
{
    public class NewBidViewModel : IBidViewModel
    {
        
        public decimal Value { get; set; }
        private IBidsRepository bidsRepo;
        private IAuctionsRepository auctionRepo;
        public NewBidViewModel()
        {
            this.bidsRepo = new BidsRepository(new BidContext());
            auctionRepo = new AuctionsRepository();
        }

        public bool Bid(BidsModel bidsModel, string ID)
        {
            BidsModel bid = bidsRepo.GetMaxBidOfAuction(bidsModel.AuctionId);
            var auction = auctionRepo.GetAuctionByID(ID);
            
            if (!auctionRepo.CheckIfAuctionEnded(ID))
            {
                
                if (bid == null)
                {
                    auction.EndingPrice = bidsModel.Value;
                    bidsRepo.InsertAuction(bidsModel);
                    bidsRepo.Save();
                    return true;
                }
                else
                {
                    if (auctionRepo.CheckIfEndingPriceIsOk(bidsModel))
                    {
                        bidsRepo.InsertAuction(bidsModel);
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