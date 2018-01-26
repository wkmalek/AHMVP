using System.Collections.Generic;
using AHWForm.Models;
using AHWForm.Models.Images;

namespace AHWForm.View
{
    public interface IAuctionDetailsView
    {
        string AuctionTitle { get; set; }
        string ShortDescription { get; set; }
        string LongDescription { get; set; }
        string Price { get; set; }
        string CreatorName { get; set; }
        string DateCreated { get; set; }
        string DataEnd { get; set; }
        List<AuctionBidViewModel> bids { get; set; }
        List<ImagesModel> listOFImages { get; set; }
        string Currency { get; set; }
        bool IsEnded { get; set; }
    }
}