using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.View;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace AHWForm.Models
{
    public class AuctionListSingleElemVM : SingleAuctionViewModel
    {
        public AuctionListSingleElemVM(AuctionModel auctionModel)
        {
            AuctionTitle = auctionModel.Title;
            ActualPrice = auctionModel.EndingPrice.ToString();
            //Currency
            CreatorName = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(auctionModel.CreatorId).UserName;
            CreatorId = auctionModel.CreatorId;
            ShortDescription = auctionModel.Description;
            DateCreated = auctionModel.DateCreated.ToString();
            DateEnd = (auctionModel.DateCreated.AddDays(auctionModel.ExpiresIn)).ToString();
        }
    }
}