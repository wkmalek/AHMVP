using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using AHWForm.Models;
using AHWForm.Presenter;
using AHWForm.View;

namespace AHWForm
{
    public partial class AuctionListPage : System.Web.UI.Page, IAuctionListView
    {
        public List<AuctionListSingleElemVM> vm { get; set; }
        private AuctionListPresenter p;

        protected void Page_Load(object sender, EventArgs e)
        {
            p = new AuctionListPresenter(new AuctionListModel(), this);
                p.PopulateAuctionList(HttpContext.Current.Request.Cookies["currency"].Value);
                AuctionList.DataSource = vm;
                AuctionList.DataBind();
                InitializeCulture();
        }

        protected void FilterByPriceAscending_OnClick(object sender, EventArgs e)
        {
            AuctionList.Sort("StartPrice", SortDirection.Ascending);
        }

        protected void FilterByPriceDescending_OnClick(object sender, EventArgs e)
        {
            AuctionList.Sort("StartPrice", SortDirection.Descending);
        }

        protected void FilterByDateAscending_OnClick(object sender, EventArgs e)
        {
           AuctionList.Sort("DateCreated", SortDirection.Ascending);
        }

        protected void FilterByDateDescending_OnClick(object sender, EventArgs e)
        {
            AuctionList.Sort("DateCreated", SortDirection.Descending);
        }

        protected void FilterByDescriptionAscending_OnClick(object sender, EventArgs e)
        {
            AuctionList.Sort("Description", SortDirection.Ascending);
        }

        protected void FilterByDescriptionDescending_OnClick(object sender, EventArgs e)
        {
            AuctionList.Sort("Description", SortDirection.Descending);
        }

        protected void AuctionList_OnSorting(object sender, ListViewSortEventArgs e)
        {
            Response.Write(e.SortDirection);
            Response.Write(e.SortExpression);
            if (e.SortDirection == SortDirection.Ascending)
            {
                if (e.SortExpression == "StartPrice")
                { 
                    var y = vm.OrderBy(x => Convert.ToDecimal(x.ActualPrice)).ToList();
                    vm = y;
                }
                if (e.SortExpression == "DateCreated")
                    vm = vm.OrderBy(x => x.DateCreated).ToList();
                if (e.SortExpression == "Description")
                    vm = vm.OrderBy(x => x.ShortDescription).ToList();
            }
            else
            {
                if (e.SortExpression == "StartPrice")
                    vm = vm.OrderByDescending(x => Convert.ToDecimal(x.ActualPrice)).ToList();
                if (e.SortExpression == "DateCreated")
                    vm = vm.OrderByDescending(x => x.DateCreated).ToList();
                if (e.SortExpression == "Description")
                    vm = vm.OrderByDescending(x => x.ShortDescription).ToList();
            }

            AuctionList.DataSource = vm;
            AuctionList.DataBind();
        }
    }
}