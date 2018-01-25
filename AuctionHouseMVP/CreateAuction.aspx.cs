using AHWForm.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Classes_And_Interfaces;
using AHWForm.Models.Auctions.CreateAuction;
using AHWForm.Presenter;
using AHWForm.View;

namespace AHWForm
{
    public partial class CreateAuction : System.Web.UI.Page, ICreateAuctionView
    {
        private CreateAuctionPresenter p;
        public IEnumerable<CategoryModel> tv { get; set; }
        private List<string> fileID;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            fileID  = new List<string>();
            p = new CreateAuctionPresenter(new CreateAuctionModel(), this);
            if (!this.IsPostBack)
            {
                Session["ListOfImages"] = fileID;
                for (int i = 0; i < 16; i++)
                {
                    ExpiresInDropDown.Items.Add(i.ToString());
                }
                p.Populate();
                ExtensionMethods.PopulateNodes(tv, NewAuctionTreeView);
                NewAuctionTreeView.CollapseAll();
            }
        }

        protected void PassNewAuctionButton_Click(object sender, EventArgs e)
        {
            fileID = (List<string>)Session["ListOfImages"];
            CreateAuctionViewModel vm = new CreateAuctionViewModel()
            {
                AuctionTitle = AuctionTitleTextBox.Text,
                ActualPrice = MinimalPriceTextBox.Text,
                ExpiresIn = Int32.Parse(ExpiresInDropDown.SelectedItem.Value),
                ShortDescription = DescriptionTextBox.Text,
                LongDescription = DescriptionLongTextBox.Text,
                CategoryId = NewAuctionTreeView.SelectedValue,
                ImageGuid = fileID,
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
                fileID.Add(name+ext);
                Session["ListOfImages"] = fileID;
                Console.Write("");
            }
        }
    }
}