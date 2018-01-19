using AHWForm.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Classes_And_Interfaces;
using AHWForm.Models.Auctions.CreateAuction;
using AHWForm.Presenter;
using AHWForm.View;

namespace AHWForm
{
    public partial class CreateAuction : System.Web.UI.Page, IExtensionMethods, ICreateAuctionView
    {
        private CreateAuctionPresenter p;
        public IEnumerable<CategoryModel> tv { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            p = new CreateAuctionPresenter(new CreateAuctionModel(), this);
            if (!this.IsPostBack)
            {
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
            CreateAuctionViewModel vm = new CreateAuctionViewModel()
            {
                AuctionTitle = AuctionTitleTextBox.Text,
                ActualPrice = MinimalPriceTextBox.Text,
                ExpiresIn = Int32.Parse(ExpiresInDropDown.SelectedItem.Value),
                ShortDescription = DescriptionTextBox.Text,
                LongDescription = DescriptionLongTextBox.Text,
                CategoryId = NewAuctionTreeView.SelectedValue,
            };
            p.CreateAuction(vm);
            //Response.Redirect("~/AuctionDetails?Id=" + vm.Id);

        }

        
    }
}