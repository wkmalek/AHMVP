using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.ExtMethods;
using AHWForm.Models;
using AHWForm.Models.Images;
using AHWForm.Repos;
using AHWForm.View;
using Repositories;

namespace AHWForm.Models
{
    public class AuctionDetailsModel : IAuctionDetailsModel
    {
        private readonly AuctionsRepository auctionRepo;
        private readonly BidsRepository bidsRepo;
        private readonly ImageRepository imageRepo;

        public AuctionDetailsModel()
        {
            auctionRepo = RepositoryFactory.GetRepositoryInstance<AuctionModel, AuctionsRepository>();
            bidsRepo = RepositoryFactory.GetRepositoryInstance<BidsModel, BidsRepository>();
            imageRepo = RepositoryFactory.GetRepositoryInstance<ImagesModel, ImageRepository>();
        }

        public AuctionDetailsViewModel LoadAuction(string ID, string currency,
            ICurrencyExchangeRepository currencyExchangeRepository)
        {
            try
            {
                //TODO
                auctionRepo.CheckIfAuctionEnded(ID);
                auctionRepo.CheckIfEndingPriceIsOk(bidsRepo.GetMaxBidOfAuction(ID));
                var auction = auctionRepo.GetSingleElementByID(ID);
                var startPrice =
                    currencyExchangeRepository.GetValueInAnotherCurrency(auction.StartPrice, auction.Currency,
                        currency);
                var endingPrice =
                    currencyExchangeRepository.GetValueInAnotherCurrency(auction.EndingPrice, auction.Currency,
                        currency);
                auction.EndingPrice = endingPrice;
                auction.StartPrice = startPrice;
                auction.Currency = currency;
                var bids = bidsRepo.GetBidsByAuctionID(ID);
                var bidsVM = new AuctionBidsViewModel(bids);
                var img = imageRepo.GetImagesByAuctionID(ID).ToList();

                return new AuctionDetailsViewModel(auction, bidsVM, img);
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        ~AuctionDetailsModel()
        {
            auctionRepo.Dispose();
            bidsRepo.Dispose();
            imageRepo.Dispose();
        }
    }

    public class AuctionDetailsViewModel : SingleAuctionViewModel
    {
        public AuctionDetailsViewModel(AuctionModel auc, IAuctionBidsViewModel bid, List<ImagesModel> img)
        {
            AuctionTitle = auc.Title;
            ActualPrice = auc.EndingPrice.ToString();
            Currency = auc.Currency;
            CreatorName = UserHelper.GetUserNameById(auc.CreatorId);
            CreatorId = auc.CreatorId;
            ShortDescription = auc.Description;
            LongDescription = auc.LongDescription;
            DateCreated = auc.DateCreated.ToString();
            DateEnd = (auc.DateCreated.AddDays(auc.ExpiresIn)).ToString();

            bidsViewModel = bid;
            Id = auc.Id;
            IsEnded = auc.IsEnded;
            imgModel = img;
        }

        public string LongDescription { get; private set; }
        public IAuctionBidsViewModel bidsViewModel { get; private set; }
        public List<ImagesModel> imgModel { get; private set; }

        
    }
}