using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Helper;
using AHWForm.Models;
using AHWForm.Presenter;
using Elmah;
using NUnit.Framework;

namespace AHWForm
{
    public partial class AuctionListPage : Page, IAuctionListView
    {
        private AuctionListPresenter p;
        public List<AuctionListSingleElemVM> vm { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            p = new AuctionListPresenter(new AuctionListModel(), this);

            p.PopulateAuctionList(CookieHelper.CheckCookie("currency", "USD"));
            List<AuctionListSingleElemVM> list = new List<AuctionListSingleElemVM>();
            foreach (var item in vm)
            {
                if (!item.IsEnded)
                    list.Add(item);
            }
            AuctionList.DataSource = list;
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
                    try
                    {
                        var y = vm.OrderBy(x => Convert.ToDecimal(x.ActualPrice)).ToList();
                        vm = y;
                    }
                    catch (Exception ex)
                    {
                        ErrorSignal.FromCurrentContext().Raise(ex);
                    }
                }

                if (e.SortExpression == "DateCreated")
                    vm = vm.OrderBy(x => x.DateCreated).ToList();
                if (e.SortExpression == "Description")
                    vm = vm.OrderBy(x => x.ShortDescription).ToList();
            }
            else
            {
                if (e.SortExpression == "StartPrice")
                {
                    try
                    {
                        var y = vm.OrderByDescending(x => Convert.ToDecimal(x.ActualPrice)).ToList();
                        vm = y;
                    }
                    catch (Exception ex)
                    {
                        ErrorSignal.FromCurrentContext().Raise(ex);
                    }
                }

                if (e.SortExpression == "DateCreated")
                    vm = vm.OrderByDescending(x => x.DateCreated).ToList();
                if (e.SortExpression == "Description")
                    vm = vm.OrderByDescending(x => x.ShortDescription).ToList();
            }

            List<AuctionListSingleElemVM> list = new List<AuctionListSingleElemVM>();
            if (!WithEndedAuctions.Checked)
                foreach (var item in vm)
                {
                    if (!item.IsEnded)
                        list.Add(item);

                }
            else
            {
                list = vm;
            }
            AuctionList.DataSource = list;
            AuctionList.DataBind();

        }


        protected void WithEndedAuctions_OnCheckedChanged(object sender, EventArgs e)
        {
             List<AuctionListSingleElemVM> list = new List<AuctionListSingleElemVM>();
            if(!WithEndedAuctions.Checked)
            foreach (var item in vm)
            {
                if(!item.IsEnded)
                    list.Add(item);

            }
            else
            {
                list = vm;
            }
                AuctionList.DataSource = list;
            AuctionList.DataBind();

        }
    }
}