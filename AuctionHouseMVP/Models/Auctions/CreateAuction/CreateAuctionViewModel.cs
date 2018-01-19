using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.ExtMethods;

namespace AHWForm.Models.Auctions.CreateAuction
{
    public class CreateAuctionViewModel:SingleAuctionViewModel
    {
        public string LongDescription { get; set; }
        public int ExpiresIn { get; set; }
        public string CategoryId { get; set; }

        public CreateAuctionViewModel()
        {
                
        }

        internal AuctionModel GetModel()
        {
            
            return new AuctionModel()
            {
                Title = this.AuctionTitle,
                StartPrice = Decimal.Parse(this.ActualPrice),
                EndingPrice = Decimal.Parse(this.ActualPrice),
                Description = this.ShortDescription,
                LongDescription = this.LongDescription,
                IsEnded = false,
                DateCreated = DateTime.Now,
                ExpiresIn = ExpiresIn,
                CreatorId = UserHelper.GetCurrentUser(),
                Id = Guid.NewGuid().ToString(),
                //Currency = "USD";
                CategoryId = CategoryId,
               
            };
        }
    }
}