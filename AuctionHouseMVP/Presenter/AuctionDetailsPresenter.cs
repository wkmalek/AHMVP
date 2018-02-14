using System;
using System.Linq;
using System.Web;
using AHWForm.Helper;
using AHWForm.Models;
using AHWForm.Repos;
using AHWForm.View;
using AHWForm.ExtMethods;

namespace AHWForm.Presenter
{
    public class AuctionDetailsPresenter : AbstractPresenter<IAuctionDetailsView>
    {
        internal readonly IAuctionDetailsModel _pModel = new AuctionDetailsModel();

        internal void Bid()
        {
            //Here is just redirecting to bid site
            HttpContext.Current.Response.Redirect("~/Bid?Id=" + HttpContext.Current.Request.QueryString["ID"]);
        }

        internal void PopulateAuction()
        {

            //load query string and pass to method
            var currency = CookieHelper.CheckCookie("currency", "USD");
            var qs = UrlHelper.GetQueryString("Id");
            var vm = _pModel.LoadAuction(qs, currency, new CurrencyExchangeRepository());

            if (vm != null)
                try
                {
                        _pView.AuctionTitle = vm.AuctionTitle;
                        _pView.CreatorName = vm.CreatorName;
                        _pView.DateCreated = vm.DateCreated;
                        _pView.LongDescription = vm.LongDescription;
                        _pView.Price = vm.ActualPrice;
                        _pView.ShortDescription = vm.ShortDescription;
                        _pView.bids = vm.bidsViewModel.bidsViewModel.OrderByDescending(x => x.Value).ToList();
                        _pView.listOFImages = vm.imgModel;
                        _pView.Currency = currency;
                        _pView.DataEnd = vm.DateEnd;
                        _pView.IsEnded = vm.IsEnded;

                        if (_pView.listOFImages != null)
                            foreach (var item in _pView.listOFImages)
                            {
                                if (item.IsThumbnail)
                                    _pView.Thumbnail = ImageHelper.GetUrlForImage(item.Id, item.Extension);
                            }
                }
                catch (Exception e)
                {
                    Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                    throw e;
                }
            else
            {
                throw new HttpException(404, "Not found auction with ID: " + qs);
            }

        }
    }
}