using AHWForm.ExtMethods;
using AHWForm.Repos;

namespace AHWForm.Models
{
    public class AuctionListSingleElemVM : SingleAuctionViewModel
    {
        public AuctionListSingleElemVM(AuctionModel auctionModel, string currency,
            ICurrencyExchangeRepository exchangeRepository)
        {
            Id = auctionModel.Id;
            AuctionTitle = auctionModel.Title;
            ActualPrice = exchangeRepository
                .GetValueInAnotherCurrency(auctionModel.EndingPrice, auctionModel.Currency, currency).ToString();
            Currency = currency;
            CreatorName = UserHelper.GetUserNameById(auctionModel.CreatorId);
            CreatorId = auctionModel.CreatorId;
            ShortDescription = auctionModel.Description;
            DateCreated = auctionModel.DateCreated.ToString();
            DateEnd = (auctionModel.DateCreated.AddDays(auctionModel.ExpiresIn)).ToString();
            AuctionUrl = "~/AuctionDetails?ID=" + Id;
            IsEnded = auctionModel.IsEnded;
        }

        public string AuctionUrl { get; }
    }
}