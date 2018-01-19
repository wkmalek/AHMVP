using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using AHWForm.Models.Auctions.CreateAuction;
using AHWForm.View;

namespace AHWForm.Presenter
{
    public class CreateAuctionPresenter
    {
        private ICreateAuctionModel _pModel;
        private ICreateAuctionView _pView;

        public CreateAuctionPresenter(ICreateAuctionModel PModel, ICreateAuctionView PView)
        {
            _pModel = PModel;
            _pView = PView;
        }

        internal void CreateAuction(CreateAuctionViewModel auc)
        {
            _pModel.CreateAuction(auc);
            HttpContext.Current.Response.Redirect("~/AuctionDetails?Id=" + _pModel.Id);           
        }

        internal void Populate()
        {
            _pView.tv = _pModel.LoadCategories();
        }
    }
}