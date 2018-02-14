using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Helper;
using AHWForm.Models;
using Elmah;

namespace AHWForm
{
    public partial class SortControl : System.Web.UI.UserControl
    {
        public List<AuctionListSingleElemVM> vm;
        private ListView lv;

        public ListView al
        {
            get { return lv; }
            set { lv = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void FrameworkInitialize()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(CookieHelper.CheckCookie("lang", "en-Us"));
            base.FrameworkInitialize();
        }

        protected void FilterByPriceAscending_OnClick(object sender, EventArgs e)
        {
            Sort("StartPrice", SortDirection.Ascending);
        }

        protected void FilterByPriceDescending_OnClick(object sender, EventArgs e)
        {
            Sort("StartPrice", SortDirection.Descending);
        }

        protected void FilterByDateAscending_OnClick(object sender, EventArgs e)
        {
            Sort("DateCreated", SortDirection.Ascending);
        }

        protected void FilterByDateDescending_OnClick(object sender, EventArgs e)
        {
            Sort("DateCreated", SortDirection.Descending);
        }

        protected void FilterByDescriptionAscending_OnClick(object sender, EventArgs e)
        {
            Sort("Description", SortDirection.Ascending);
        }

        protected void FilterByDescriptionDescending_OnClick(object sender, EventArgs e)
        {
            Sort("Description", SortDirection.Descending);
        }

        protected void WithEndedAuctions_OnCheckedChanged(object sender, EventArgs e)
        {
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
            al.DataSource = list;
            al.DataBind();

        }

        protected void Sort(string SortExpression, SortDirection SortDirection)
        {
            Response.Write(SortDirection);
            Response.Write(SortExpression);
            if (SortDirection == SortDirection.Ascending)
            {
                if (SortExpression == "StartPrice")
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

                if (SortExpression == "DateCreated")
                    vm = vm.OrderBy(x => x.DateCreated).ToList();
                if (SortExpression == "Description")
                    vm = vm.OrderBy(x => x.ShortDescription).ToList();
            }
            else
            {
                if (SortExpression == "StartPrice")
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

                if (SortExpression == "DateCreated")
                    vm = vm.OrderByDescending(x => x.DateCreated).ToList();
                if (SortExpression == "Description")
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
            al.DataSource = list;
            al.DataBind();

        }
    }
}