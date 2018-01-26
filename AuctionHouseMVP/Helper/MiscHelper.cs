using AHWForm.Repos;

namespace AHWForm.ExtMethods
{
    public static class MiscHelper
    {
        public static string GetAuctionTitle(string ID)
        {
            AuctionsRepository repo = new AuctionsRepository();
            return repo.GetSingleElementByID(ID).Title;
        }
    }
}