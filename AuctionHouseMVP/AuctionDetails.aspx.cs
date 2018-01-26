using System;
using System.Collections.Generic;
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
    public partial class AuctionDetails : Page, IAuctionDetailsView
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
            set { BidsList.DataSource = value; }
        }

        public List<ImagesModel> listOFImages { get; set; }

        public string Currency
        {
            get { return CurrencyLabel.Text; }
            set { CurrencyLabel.Text = value; }
        }

        public bool IsEnded
        {
            get { return IsEnded; }
            set { Bid.Visible = !value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AuctionDetailsPresenter p = new AuctionDetailsPresenter(new AuctionDetailsModel(), this);
            p.PopulateAuction(CookieHelper.CheckCookie("currency", "USD"));
            if (listOFImages != null)
                foreach (var item in listOFImages)
                {
                    if (item.IsThumbnail)
                        Thumbnail.ImageUrl = ImageHelper.GetUrlForImage(item.Id, item.Extension);
                }

            ImageGallery.DataSource = listOFImages;
            ImageGallery.DataBind();
            BidsList.DataBind();
        }

        protected override void InitializeCulture()
        {
            var langCookie = CookieHelper.CheckCookie("lang", "en-US");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(langCookie);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCookie);
            base.InitializeCulture();
        }

        protected void Bid_Click(object sender, EventArgs e)
        {
            AuctionDetailsPresenter p = new AuctionDetailsPresenter(new AuctionDetailsModel(), this);
            p.Bid();
        }
    }
}