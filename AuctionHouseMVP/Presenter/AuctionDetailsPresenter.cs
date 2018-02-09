using System.Linq;
using System.Web;
using AHWForm.Helper;
using AHWForm.Models;
using AHWForm.Repos;
using AHWForm.View;

namespace AHWForm.Presenter
{
    public class AuctionDetailsPresenter<T,U> : AbstractPresenter<T,U> where T : IModel where U : IMVPView

    {
        internal readonly IAuctionDetailsModel _pModel;
        internal readonly IAuctionDetailsView _pView;

        public AuctionDetailsPresenter(T PModel, U PView) : base(PModel, PView)
        {
        }

        internal void Bid()
        {
            //Here is just redirecting to bid site
            HttpContext.Current.Response.Redirect("~/Bid?Id=" + HttpContext.Current.Request.QueryString["ID"]);
        }

        internal void PopulateAuction(string currency)
        {
            //load query string and pass to method

            var qs = UrlHelper.GetQueryString("Id");
            var vm = _pModel.LoadAuction(qs, currency, new CurrencyExchangeRepository());
            if (vm != null)
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
            }
            else
            {
                //TODO
                throw new HttpException(404, "Not found auction with ID: " + qs);
            }
        }
    }
}