using AHWForm.Repos;

namespace AHWForm.Models
{
    public interface IAuctionDetailsModel : IModel
    {
        AuctionDetailsViewModel LoadAuction(string ID, string currency, ICurrencyExchangeRepository currencyRepository);
    }
}