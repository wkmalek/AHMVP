using AHWForm.Repos;
using AHWForm.View;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHWForm.Models
{
    public class AuctionDetailsModel : IAuctionDetailsModel
    {
        private IAuctionsRepository auctionRepo {get;set;}
        private IBidsRepository bidsRepo { get; set; }


        public AuctionDetailsModel(IAuctionsRepository auctionRepo, IBidsRepository bidsRepo)
        {
            this.auctionRepo = auctionRepo;
            this.bidsRepo = bidsRepo;
        }

        public AuctionDetailsViewModel LoadAuction(string ID)
        {
            var auction = auctionRepo.GetAuctionByID(ID);
            var bids = bidsRepo.GetBidsByAuctionID(ID);
            var bidsVM = new AuctionBidsViewModel(bids);
            return new AuctionDetailsViewModel(auction, bidsVM);   
        }

    }

    public class AuctionDetailsViewModel : SingleAuctionViewModel
    {

        public string LongDescription { get; set; }
        public IAuctionBidsViewModel bidsViewModel { get; set; }

        public AuctionDetailsViewModel(AuctionModel auc, IAuctionBidsViewModel bid)
        {
            AuctionTitle = auc.Title;
            ActualPrice = auc.EndingPrice.ToString();
            //Currency = auc.Currency;
            CreatorName = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(auc.CreatorId).UserName;
            CreatorId = auc.CreatorId;
            ShortDescription = auc.Description;
            LongDescription = auc.LongDescription;
            DateCreated = auc.DateCreated.ToString();
            //??
            DateEnd = (auc.DateCreated.AddDays(auc.ExpiresIn)).ToString();

            //bidsView
            bidsViewModel = bid;
            Id = auc.Id;
            IsEnded = IsEnded;

        }

        
    }
}