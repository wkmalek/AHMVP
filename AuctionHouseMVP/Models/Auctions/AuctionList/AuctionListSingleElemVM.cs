using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using AHWForm.Classes_And_Interfaces;
using AHWForm.ExtMethods;
using AHWForm.View;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace AHWForm.Models
{
    public class AuctionListSingleElemVM : SingleAuctionViewModel
    {
        public string AuctionUrl { get; set; }
        public AuctionListSingleElemVM(AuctionModel auctionModel)
        {
            Id = auctionModel.Id;
            AuctionTitle = auctionModel.Title;
            ActualPrice = auctionModel.EndingPrice.ToString();
            //Currency
            CreatorName = UserHelper.GetUserNameById(auctionModel.CreatorId);
            CreatorId = auctionModel.CreatorId;
            ShortDescription = auctionModel.Description;
            DateCreated = auctionModel.DateCreated.ToString();
            DateEnd = (auctionModel.DateCreated.AddDays(auctionModel.ExpiresIn)).ToString();
            AuctionUrl = "~/AuctionDetails?ID=" + Id;
        }
    }
}