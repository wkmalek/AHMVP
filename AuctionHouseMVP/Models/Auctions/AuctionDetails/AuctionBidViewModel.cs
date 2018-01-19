using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHWForm.Models
{
    public class AuctionBidViewModel
    {
        public string Bidder { get; set; }
        public string Value { get; set; }
        public string DateCreated { get; set; }
        public string Id { get; set; }

        public AuctionBidViewModel(BidsModel bids)
        {
            Bidder = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(bids.UserId).UserName;
            Value = bids.Value.ToString();
            //TODO
            DateCreated = DateTime.Now.ToString();
            Id = bids.Id;
        }

       
    }
}