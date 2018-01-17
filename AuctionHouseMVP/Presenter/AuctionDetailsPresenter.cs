﻿using AHWForm.Models;
using AHWForm.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHWForm.Presenter
{
    public class AuctionDetailsPresenter

    {
        IAuctionDetailsModel _pModel;
        IAuctionDetailsView _pView;

        public AuctionDetailsPresenter(IAuctionDetailsModel PModel, IAuctionDetailsView PView)
        {
            _pModel = PModel;
            _pView = PView;
        }



        internal void Bid()
        {
            //Here is just redirecting to bid site
            throw new NotImplementedException();
        }

        internal void PopulateAuction()
        {  
            //load query string and pass to method
            var vm = _pModel.LoadAuction("1330ed01-c6a2-4474-a641-2f23a2f3b793");
            _pView.AuctionTitle = vm.ActualPrice;
            _pView.CreatorName = vm.CreatorName;
            _pView.DateCreated = vm.DateCreated;
            _pView.LongDescription = vm.LongDescription;
            _pView.Price = vm.ActualPrice;
            _pView.ShortDescription = vm.ShortDescription;
            

        }
    }
}