using System;
using System.Web;
using AHWForm.ExtMethods;
using AHWForm.Helper;
using AHWForm.Models;
using AHWForm.View;

namespace AHWForm.Presenter
{
    public class BidPresenter
    {
        private IBidViewModel _pModel;
        private IBidView _pView;

        public BidPresenter(IBidViewModel PModel, IBidView PView)
        {
            _pModel = PModel;
            _pView = PView;
        }

        internal void Load()
        {
            var qs = UrlHelper.GetQueryString("Id");
            if (!_pModel.CheckAuction(qs))
                throw new HttpException(404, "Auction not found");
            _pView.ActualValue = _pModel.GetAuctionModel(qs).EndingPrice;
        }

        internal void Bid()
        {
            try
            {
                var qs = UrlHelper.GetQueryString("Id");
                decimal value = Decimal.Parse(_pView.Value);
                if (!_pModel.Bid(new BidsModel
                {
                    AuctionId = qs,
                    Value = value,
                    UserId = UserHelper.GetCurrentUser(),
                    Id = Guid.NewGuid().ToString(),
                    DateCreated = DateTime.Now
                }, qs))
                {
                    throw new HttpException(404, "AuctionNotCreated");
                }

                //should refresh db
                HttpContext.Current.Response.Redirect("~/AuctionDetails?Id=" + qs);
            }
            catch(Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                throw new FormatException(ex.StackTrace,ex.InnerException);
            }
            
        }
    }
}