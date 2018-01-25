﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using AHWForm.Repos;

namespace AHWForm.Models
{
    public class AuctionListSingleElemVM : SingleAuctionViewModel
    {
        public string AuctionUrl { get; set; }
        public AuctionListSingleElemVM(AuctionModel auctionModel, string currency, ICurrencyExchangeRepository exchangeRepository, string username)
        {
            
            Id = auctionModel.Id;
            AuctionTitle = auctionModel.Title;
            ActualPrice = exchangeRepository.GetValueInAnotherCurrency(auctionModel.EndingPrice, auctionModel.Currency, currency).ToString();
            Currency = currency;
            CreatorName = username;
            CreatorId = auctionModel.CreatorId;
            ShortDescription = auctionModel.Description;
            DateCreated = auctionModel.DateCreated.ToString();
            DateEnd = (auctionModel.DateCreated.AddDays(auctionModel.ExpiresIn)).ToString();
            AuctionUrl = "~/AuctionDetails?ID=" + Id;
        }

        
    }
}