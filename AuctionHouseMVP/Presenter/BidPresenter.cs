using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.ExtMethods;
using AHWForm.Models;
using AHWForm.View;

namespace AHWForm.Presenter
{
    public class BidPresenter
    {
        public IBidViewModel _pModel;
        public IBidView _pView;

        public BidPresenter(IBidViewModel PModel, IBidView PView)
        {
            _pModel = PModel;
            _pView = PView;
        }

        internal void Bid()
        {
            string id = HttpContext.Current.Request.QueryString["Id"];
            decimal value = Decimal.Parse(_pView.Value);
            _pModel.Bid(new BidsModel()
            {
                AuctionId = id,
                Value = value,
                UserId = UserHelper.GetCurrentUser(),
                Id = Guid.NewGuid().ToString(),
                DateCreated = DateTime.Now,
            }, id);

            //should refresh db
            HttpContext.Current.Response.Redirect("~/AuctionDetails?Id=" + id);
        }
    }
}