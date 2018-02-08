using AHWForm.Repos;

namespace AHWForm.ExtMethods
{
    public static class MiscHelper
    {
        public static string GetAuctionTitle(string ID)
        {
            var repo = new AuctionsRepository();
            return repo.GetSingleElementByID(ID).Title;
        }
    }
}