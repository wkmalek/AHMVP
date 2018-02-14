using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Helper;
using AHWForm.Models;
using AHWForm.Presenter;
using AHWForm.View;
using Elmah;
using NUnit.Framework;

namespace AHWForm
{
    public partial class AuctionListPage : ViewBasePage<AuctionListPresenter, IAuctionListView>, IAuctionListView
    {
        private List<AuctionListSingleElemVM> _auctionModel;

        public List<AuctionListSingleElemVM> vm
        {
            get { return _auctionModel; }
            set
            {
                AuctionList.DataSource = value;
                _auctionModel = value;
                sortControl.vm = vm;
                AuctionList.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                sortControl.al = AuctionList;
                _presenter.PopulateAuctionList();
            }
        }

    }
}