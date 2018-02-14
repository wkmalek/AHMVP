using AHWForm.ExtMethods;

namespace AHWForm.Models
{
    public class AuctionBidViewModel
    {
        public AuctionBidViewModel(BidsModel bids)
        {
            Bidder = UserHelper.GetUserNameById(bids.UserId);
            Value = bids.Value.ToString();
            DateCreated = bids.DateCreated.ToString();
            Id = bids.Id;
        }

        public string Bidder { get; set; }
        public string Value { get; set; }
        public string DateCreated { get; set; }
        public string Id { get; set; }
    }
}