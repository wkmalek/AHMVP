using System.ComponentModel.DataAnnotations;
using AHWForm.Classes_And_Interfaces;
using AHWForm.ExtMethods;

namespace AHWForm.Models.Comments
{
    public class CommentsBuyView
    {
        public CommentsBuyView(CommentsModel model, bool CommentGranted)
        {
            Id = model.Id;
            AuctionUrl = UrlHelper.GetUrlForAuction(model.AuctionId);
            AuctionTitle = MiscHelper.GetAuctionTitle(model.AuctionId);
            BuyerUrl = UrlHelper.GetUrlForUserSite(model.BuyerId);
            BuyerName = UserHelper.GetUserNameById(model.BuyerId);
            SellerName = UserHelper.GetUserNameById(model.SellerId);
            SellerUrl = UrlHelper.GetUrlForUserSite(model.SellerId);
            Rate = model.Rate;
            Description = model.Description;
            WriteCommentUrl = UrlHelper.GetUrlForWriteComment(model);
            this.CommentGranted = CommentGranted;
        }

        [ScaffoldColumn(false)]
        public string Id { get; set; }
        public string AuctionUrl { get; set; }
        public string AuctionTitle { get; set; }
        public string BuyerUrl { get; set; }
        public string BuyerName { get; set; }
        public string SellerName { get; set; }
        public string SellerUrl { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
        public string WriteCommentUrl { get; set; }
        public bool CommentGranted { get; set; }
    }
}