using AHWForm.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Classes_And_Interfaces;
using AHWForm.View;
using AHWForm.Presenter;

namespace AHWForm
{
    public partial class AuctionDetails : System.Web.UI.Page, IAuctionDetailsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuctionDetailsPresenter p = new AuctionDetailsPresenter(new AuctionDetailsModel(), this);
            p.PopulateAuction();
        }

        public string AuctionTitle {get { return AuctionTitleLabel.Text; } set { AuctionTitleLabel.Text = value; } }
        public string ShortDescription { get { return AuctionShortDescription.Text; }set { AuctionShortDescription.Text = value; } }
        public string LongDescription { get { return AuctionLongDescription.Text; }set { AuctionLongDescription.Text = value; } }
        public string Price { get { return AuctionPrice.Text; } set { AuctionPrice.Text = value; } }
        public string CreatorName { get { return AuctionCreatorName.Text; }set { AuctionCreatorName.Text = value; } }
        public string DateCreated { get { return AuctionCreated.Text; } set { AuctionCreated.Text = value; } }
        
        protected void Bid_Click(object sender, EventArgs e)
        {
            AuctionDetailsPresenter p = new AuctionDetailsPresenter(new AuctionDetailsModel(), this);
            p.Bid();
        }


    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           