using System.Web;
using AHWForm.Helper;

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
            UrlHelper.RedirectToAuction(UrlHelper.GetUrlForAuction(id));
        }

        internal void PopulateAuctionList(string currency)
        {
            var qs = UrlHelper.GetQueryString("category");
            var vm = _pModel.LoadAuctions(qs, currency);
            if (vm != null)
                _pView.vm = vm.mainList;
            else
                throw new HttpException(404, "Not found selected category: " + qs);
        }
    }
}