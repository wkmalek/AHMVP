using AHWForm.Repos;

namespace AHWForm.Models
{
    public interface IAuctionDetailsModel
    {
        AuctionDetailsViewModel LoadAuction(string ID, string currency, ICurrencyExchangeRepository currencyRepository);
    }
}