using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.ExtMethods;
using AHWForm.Helper;
using AHWForm.Models;
using AHWForm.Presenter;
using AHWForm.View;
using Microsoft.AspNet.Identity;

namespace AHWForm
{
    public partial class SiteMaster : MasterPage, IMasterPageView
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        public IEnumerable<CategoryModel> tv { get; set; }


        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }

                Response.Cookies.Set(responseCookie);
            }

            if (Request.Cookies["lang"] == null)
            {
                //Write cookie with default lang
                HttpCookie langCookie = new HttpCookie("lang");
                langCookie.Value = "en-US";
                langCookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(langCookie);
            }

            if (Request.Cookies["currency"] == null)
            {
                //Write coockie with default currency
                HttpCookie currencyCookie = new HttpCookie("currency");
                currencyCookie.Value = "USD";
                currencyCookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(currencyCookie);
            }

            Thread.CurrentThread.CurrentCulture =
                CultureInfo.CreateSpecificCulture(CookieHelper.CheckCookie("lang", "en-Us"));
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CookieHelper.CheckCookie("lang", "en-Us"));

            Page.PreLoad += master_Page_PreLoad;
        }


        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string) ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string) ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MasterPagePresenter p = new MasterPagePresenter(new MasterPageViewModel(), this);
                p.PopulateMasterPage();
                TreeHelper.PopulateNodes(tv, CategoriesTreeView);
                CategoriesTreeView.CollapseAll();
                if (!UserHelper.IsUserLoggedIn())
                {
                    CreateAuctionLabel.Visible = false;
                }
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void CategoriesTreeView_OnSelectedNodeChanged(object sender, EventArgs e)
        {
            var value = CategoriesTreeView.SelectedNode.Value;
            Response.Redirect("/AuctionListPage?category=" + value);
        }
    }
}