namespace AHWForm.Models
{
    public interface IBidViewModel
    {
        bool Bid(BidsModel bidsModel, string ID);
        bool CheckAuction(string ID);
        AuctionModel GetAuctionModel(string ID);
    }
}