﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Presenter;
using AHWForm.Repos;

namespace AHWForm.Models
{
    public class AuctionListViewModel 
    {
        public List<AuctionListSingleElemVM> mainList { get; set; }
        public AuctionListViewModel(IEnumerable<AuctionModel> auctionModels, string currency)
        {
            mainList = new List<AuctionListSingleElemVM>();
            foreach (var item in auctionModels)
            {
                mainList.Add(new AuctionListSingleElemVM(item, currency, new CurrencyExchangeRepository()));    
            }
        }

    }

    
}