using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Helper;
using AHWForm.Models;
using AHWForm.Models.Auctions.CreateAuction;
using AHWForm.Presenter;
using AHWForm.View;

namespace AHWForm
{
    public partial class CreateAuction : ViewBasePage<CreateAuctionPresenter, ICreateAuctionView>, ICreateAuctionView
    {
        private List<string> fileID;
        private IEnumerable<CategoryModel> _tv;

        public IEnumerable<CategoryModel> tv
        { 
            set
            {
                _tv = value;
                TreeHelper.PopulateNodes(_tv, NewAuctionTreeView);
                NewAuctionTreeView.CollapseAll();
            }
        }

        public string AuctionTitle
        {
            get { return AuctionTitleTextBox.Text; }
            set { AuctionTitleTextBox.Text = value; }
        }

        public string ActualPrice
        {
            get { return MinimalPriceTextBox.Text; }
            set { MinimalPriceTextBox.Text = value; }
        }

        public string ExpiresIn
        {
            get { return ExpiresInDropDown.SelectedItem.Value; }
        }

        public string ShortDescription
        {
            get { return DescriptionTextBox.Text; }
            set { DescriptionTextBox.Text = value; }
        }

        public string LongDescription
        {
            get { return DescriptionLongTextBox.Text; }
            set { DescriptionLongTextBox.Text = value; }
        }

        public string CategoryId
        {
            get { return NewAuctionTreeView.SelectedValue; }
        }

        public List<string> ImageGuid
        {
            get { return fileID; }
            set { fileID = value; }
        }

        public string Currency
        {
            get { return "USD"; }
        }

        public FileUpload file
        {
            get { return ImageUpload; }
            set { ImageUpload = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            fileID = new List<string>();
            if (IsPostBack) return;
            for (int i = 0; i < 16; i++)
            {
                ExpiresInDropDown.Items.Add(i.ToString());
            }
            
            _presenter.Populate();
        }

        protected void PassNewAuctionButton_Click(object sender, EventArgs e)
        {
            _presenter.CreateAuction();
        }

        protected void UploadImageButton_OnClick(object sender, EventArgs e)
        {
            _presenter.AddFile();
        }
    }
}