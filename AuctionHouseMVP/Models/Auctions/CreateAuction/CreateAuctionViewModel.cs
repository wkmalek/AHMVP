using System;
using System.Collections.Generic;
using System.IO;
using AHWForm.ExtMethods;
using AHWForm.Models.Images;

namespace AHWForm.Models.Auctions.CreateAuction
{
    public class CreateAuctionViewModel : SingleAuctionViewModel
    {
        public string LongDescription { get; set; }
        public int ExpiresIn { get; set; }
        public string CategoryId { get; set; }
        public List<string> ImageGuid { get; set; }

        internal AuctionModel GetModel(out List<ImagesModel> imagesModel)
        {
            var auctionId = Guid.NewGuid().ToString();
            var output = new List<ImagesModel>();
            if (ImageGuid.Count > 0)
            {
                foreach (var item in ImageGuid)
                {
                    var model = new ImagesModel
                    {
                        Id = Path.GetFileNameWithoutExtension(item),
                        AuctionID = auctionId,
                        CollectionId = "0",
                        Description = "",
                        Extension = Path.GetExtension(Path.GetExtension(item)),
                        Img = null,
                        IsThumbnail = true,
                        Title = "",
                        UserID = UserHelper.GetCurrentUser()
                    };
                    output.Add(model);
                }
            }

            imagesModel = output;

            return new AuctionModel
            {
                Title = AuctionTitle,
                StartPrice = Decimal.Parse(ActualPrice),
                EndingPrice = Decimal.Parse(ActualPrice),
                Description = ShortDescription,
                LongDescription = LongDescription,
                IsEnded = false,
                DateCreated = DateTime.Now,
                ExpiresIn = ExpiresIn,
                CreatorId = UserHelper.GetCurrentUser(),
                Id = auctionId,
                Currency = Currency,
                CategoryId = CategoryId
            };
        }
    }
}