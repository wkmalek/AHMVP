﻿using AHWForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHWForm.Repos
{
    public interface IAuctionsRepository
    {
        IEnumerable<AuctionModel> GetAuctions();
        IEnumerable<AuctionModel> GetAuctionsByCatList(IEnumerable<CategoryModel> cat);
        IEnumerable<AuctionModel> GetAuctionByUserID(string ID);
        AuctionModel GetAuctionByID(string ID);
        void InsertAuction(AuctionModel auctionModel);
        void UpdateAuction(AuctionModel auctionModel);
        void Save();
        bool CheckIfAuctionEnded(string ID);
        bool CheckIfEndingPriceIsOk(BidsModel bid);
    }
}