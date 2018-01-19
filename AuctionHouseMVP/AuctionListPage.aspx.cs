using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using AHWForm.Models;
using AHWForm.Presenter;
using AHWForm.Repos;
using AHWForm.View;

namespace AHWForm
{

    public partial class AuctionListPage : System.Web.UI.Page, IAuctionListView
    {
        public List<AuctionListSingleElemVM> vm { get; set; }
        
        private AuctionsRepository auctionsRepo = new AuctionsRepository(new AuctionContext());
        private BidsRepository bidsRepo = new BidsRepository(new BidContext());
        private CategoryRepository catRepo = new CategoryRepository(new CategoryContext());
        protected void Page_Load(object sender, EventArgs e)
        {
            AuctionListPresenter p = new AuctionListPresenter(new AuctionListModel(auctionsRepo, bidsRepo, catRepo), this);
            p.PopulateAuctionList();
            AuctionList.DataSource = vm;
            AuctionList.DataBind();
        }
    }
}