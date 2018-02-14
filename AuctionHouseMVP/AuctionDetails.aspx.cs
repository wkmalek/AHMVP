using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using AHWForm.ExtMethods;
using AHWForm.Helper;
using AHWForm.Models;
using AHWForm.Models.Images;
using AHWForm.Presenter;
using AHWForm.View;

namespace AHWForm
{
    public partial class AuctionDetails : ViewBasePage<AuctionDetailsPresenter, IAuctionDetailsView>, IAuctionDetailsView
    {
        public string AuctionTitle
        {
            get { return AuctionTitleLabel.Text; }
            set { AuctionTitleLabel.Text = value; }
        }

        public string ShortDescription
        {
            get { return AuctionShortDescription.Text; }
            set { AuctionShortDescription.Text = value; }
        }

        public string LongDescription
        {
            get { return AuctionLongDescription.Text; }
            set { AuctionLongDescription.Text = value; }
        }

        public string Price
        {
            get { return AuctionPrice.Text; }
            set { AuctionPrice.Text = value; }
        }

        public string CreatorName
        {
            get { return AuctionCreatorName.Text; }
            set { AuctionCreatorName.Text = value; }
        }

        public string DateCreated
        {
            get { return AuctionCreated.Text; }
            set { AuctionCreatedLabel.Text = value; }
        }

        public string DataEnd
        {
            get { return AuctionExpires.Text; }
            set { AuctionExpiresLabel.Text = value; }
        }

        public List<AuctionBidViewModel> bids
        {
            get { return null; }
            set
            {
                BidsList.DataSource = value;
                BidsList.DataBind();
            }
        }

        private List<ImagesModel> _listofImages;

        public List<ImagesModel> listOFImages
        {
            get { return _listofImages; }
            set
            {
                _listofImages = value;
                ImageGallery.DataSource = listOFImages;
                ImageGallery.DataBind();
            }
        }

        public string Currency
        {
            get { return CurrencyLabel.Text; }
            set { CurrencyLabel.Text = value; }
        }

        public bool IsEnded
        {
            get { return Bid.Visible;}
            set
            {
                if(value || !UserHelper.IsUserLoggedIn() || CreatorName == UserHelper.GetUserNameById(UserHelper.GetCurrentUser()))
                Bid.Visible = false;
            }
        }

        public string Thumbnail
        {
            get { return ThumbnailImg.ImageUrl; }
            set { ThumbnailImg.ImageUrl = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.PopulateAuction();
        }

        protected void Bid_Click(object sender, EventArgs e)
        {
            _presenter.Bid();
        }
    }
}