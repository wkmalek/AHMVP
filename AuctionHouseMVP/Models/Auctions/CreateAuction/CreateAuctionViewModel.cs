using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using AHWForm.ExtMethods;
using AHWForm.Models.Images;

namespace AHWForm.Models.Auctions.CreateAuction
{
    public class CreateAuctionViewModel:SingleAuctionViewModel
    {
        public string LongDescription { get; set; }
        public int ExpiresIn { get; set; }
        public string CategoryId { get; set; }
        public List<string> ImageGuid { get; set; }

        public CreateAuctionViewModel()
        {
                
        }

        internal AuctionModel GetModel(out List<ImagesModel> imagesModel)
        {
            string auctionId = Guid.NewGuid().ToString();
            List <ImagesModel> output = new List<ImagesModel>();
            if (output.Count > 0) { 
            foreach (var item in ImageGuid)
            {
                ImagesModel model = new ImagesModel()
                {
                    Id = Path.GetFileNameWithoutExtension(item),
                    AuctionID = auctionId,
                    CollectionId = "0",
                    Description = "",
                    Extension = Path.GetExtension(Path.GetExtension(item)),
                    Img = null,
                    IsThumbnail = true,
                    Title = "",
                    UserID = UserHelper.GetCurrentUser(),
                };
                output.Add(model);
            }
            }
            imagesModel = output;

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
                Id = auctionId,
                //Currency = "USD";
                CategoryId = CategoryId,
            };
        }
    }
}