using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using AHWForm.Helper;
using AHWForm.Models;
using AHWForm.Models.Auctions.CreateAuction;
using AHWForm.Presenter;
using AHWForm.View;

namespace AHWForm
{
    public partial class CreateAuction : Page, ICreateAuctionView
    {
        private List<string> fileID;
        private CreateAuctionPresenter p;
        public IEnumerable<CategoryModel> tv { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            fileID = new List<string>();
            p = new CreateAuctionPresenter(new CreateAuctionModel(), this);
            if (IsPostBack) return;
            Session["ListOfImages"] = fileID;
            for (int i = 0; i < 16; i++)
            {
                ExpiresInDropDown.Items.Add(i.ToString());
            }

            p.Populate();
            TreeHelper.PopulateNodes(tv, NewAuctionTreeView);
            NewAuctionTreeView.CollapseAll();
        }

        protected void PassNewAuctionButton_Click(object sender, EventArgs e)
        {
            fileID = (List<string>) Session["ListOfImages"];
            //Validate
            CreateAuctionViewModel vm = new CreateAuctionViewModel
            {
                AuctionTitle = AuctionTitleTextBox.Text,
                ActualPrice = MinimalPriceTextBox.Text,
                ExpiresIn = int.Parse(ExpiresInDropDown.SelectedItem.Value),
                ShortDescription = DescriptionTextBox.Text,
                LongDescription = DescriptionLongTextBox.Text,
                CategoryId = NewAuctionTreeView.SelectedValue,
                ImageGuid = fileID,
                //TODO
                Currency = "USD",
            };
            p.CreateAuction(vm);
        }

        protected void UploadImageButton_OnClick(object sender, EventArgs e)
        {
            if (ImageUpload.HasFile)
            {
                string ext = Path.GetExtension(ImageUpload.PostedFile.FileName);
                string name = Guid.NewGuid().ToString();
                ImageUpload.PostedFile.SaveAs(Server.MapPath("~/Images/") + name + ext);
                fileID = (List<string>) Session["ListOfImages"];
                fileID.Add(name + ext);
                Session["ListOfImages"] = fileID;
            }
        }
    }
}