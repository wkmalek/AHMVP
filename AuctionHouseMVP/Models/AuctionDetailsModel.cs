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
        public AuctionContext AuctionM { get; set; }
        public CategoryContext CategoryM {get; set;}
        public BidContext BidM { get; set; }

        public AuctionDetailsModel()
        {
            AuctionM = new AuctionContext();
            CategoryM = new CategoryContext();
            BidM = new BidContext();
        }

        public AuctionDetailsViewModel LoadAuction(string ID)
        {
            var auction =  AuctionM.ReturnSelectedAuction(ID, paramTypeForCategory.byAuctionId);
            return new AuctionDetailsViewModel(auction);   
        }

    }

    public class AuctionDetailsViewModel
    {
        public string AuctionTitle { get; set; }
        public string ActualPrice { get; set; }
        //public string StartingPrice { get; set; }
        public string Currency { get; set; }
        public string CreatorName { get; set; }
        //??
        public string CreatorId { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string DateCreated { get; set; }
        public string DateEnd { get; set; }
        //public List<BidsViewModel> bidsViewModel { get; set; }
        //??
        public string Id { get; set; }
        public bool IsEnded { get; set; }

        public AuctionDetailsViewModel(AuctionModel auc)
        {
            AuctionTitle = auc.Title;
            ActualPrice = auc.EndingPrice.ToString();
            //Currency = auc.Currency;
            CreatorName = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(auc.CreatorId).UserName;
            CreatorId = auc.Id;
            ShortDescription = auc.Description;
            LongDescription = auc.LongDescription;
            DateCreated = auc.DateCreated.ToString();
            //??
            DateEnd = (auc.DateCreated.AddDays(auc.ExpiresIn)).ToString();
            //bidsView
            Id = auc.Id;
            IsEnded = IsEnded;
        }
    }
}