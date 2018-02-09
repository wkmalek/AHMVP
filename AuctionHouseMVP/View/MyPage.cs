using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using AHWForm.Helper;
using AHWForm.Models;
using AHWForm.Presenter;
using System.Globalization;
using System.Threading;

namespace AHWForm.View
{
    public abstract class MyPage<T> : Page, IMVPView where T : IPresenter
    {
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            //var p = PresenterFactory.GetPresenter<T>(this);
            //var p = new AuctionListPresenter(new AuctionListModel(), this);
        }

        protected override void InitializeCulture()
        {
            var langCookie = CookieHelper.CheckCookie("lang", "en-US");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(langCookie);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCookie);
            base.InitializeCulture();
        }
    }
}