using System.Web;
using AHWForm.Helper;
using AHWForm.Models.Auctions.CreateAuction;
using AHWForm.View;

namespace AHWForm.Presenter
{
    public class CreateAuctionPresenter
    {
        private readonly ICreateAuctionModel _pModel;
        private readonly ICreateAuctionView _pView;

        public CreateAuctionPresenter(ICreateAuctionModel PModel, ICreateAuctionView PView)
        {
            _pModel = PModel;
            _pView = PView;
        }

        internal void CreateAuction(CreateAuctionViewModel auc)
        {
            if (_pModel.CreateAuction(auc))
                UrlHelper.Redirect("~/AuctionDetails?Id=" + _pModel.Id);
            else
                throw new HttpException(404, "Auction create failed");
        }

        internal void Populate()
        {
            _pView.tv = _pModel.LoadCategories();
        }
    }
}