using System.Collections.Generic;
using System.Web;
using AHWForm.Helper;
using AHWForm.Models;

namespace AHWForm.Presenter
{
    public class AuctionListPresenter : AbstractPresenter<IAuctionListView>
    {
        internal readonly IAuctionListModel _pModel = new AuctionListModel();

        internal void RedirectToAuction(string id)
        {
            UrlHelper.RedirectToAuction(UrlHelper.GetUrlForAuction(id));
        }

        internal void PopulateAuctionList()
        {
            var qs = UrlHelper.GetQueryString("category");
            var vm = _pModel.LoadAuctions(qs, CookieHelper.CheckCookie("currency", "USD"));

            if (vm != null)
                _pView.vm = vm.mainList;
            else
                throw new HttpException(404, "Not found selected category: " + qs);

            List<AuctionListSingleElemVM> list = new List<AuctionListSingleElemVM>();
            foreach (var item in _pView.vm)
            {
                if (!item.IsEnded)
                    list.Add(item);
            }

            
        }
    }
}