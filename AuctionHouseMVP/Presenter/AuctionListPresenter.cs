using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;

namespace AHWForm.Presenter
{
    public class AuctionListPresenter
    {
        public IAuctionListModel _pModel;
        public IAuctionListView _pView;

        public AuctionListPresenter(IAuctionListModel PModel, IAuctionListView PView)
        {
            _pModel = PModel;
            _pView = PView;
        }

        internal void RedirectToAuction(string id)
        {
            HttpContext.Current.Response.Redirect(
                "~/AuctionDetails/Id=" + HttpContext.Current.Request.QueryString["Id"]);      
        }

        internal void PopulateAuctionList(string currency)
        {
            var vm = _pModel.LoadAuctions(HttpContext.Current.Request.QueryString["Category"], currency);
          
            _pView.vm = vm.mainList;
        }

        
    }


}