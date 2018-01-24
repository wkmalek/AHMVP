using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using AHWForm.Models;
using System.Globalization;
using AHWForm.ExtMethods;
using AHWForm.Repos;

namespace AHWForm.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }

        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber(User.Identity.GetUserId()));

            // Enable this after setting up two-factor authentientication
            //PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;

            TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId());

            LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count;

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                // Determine the sections to render
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    CreatePassword.Visible = true;
                    ChangePassword.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : message == "AddPhoneNumberSuccess" ? "Phone number has been added"
                        : message == "RemovePhoneNumberSuccess" ? "Phone number was removed"
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
                //
                
                //TO CHANGE
                LanguageDropDown.Items.Add("en-US");
                LanguageDropDown.Items.Add("pl-PL");

                CurrencyDropDown.Items.Add("USD");
                CurrencyDropDown.Items.Add("PLN");
                try
                {
                    LanguageDropDown.Items.FindByValue(Request.Cookies["lang"].Value).Selected = true;
                }
                catch (Exception ex)
                {
                    ExHelper.HandleException(ex);
                }

                try
                {
                    CurrencyDropDown.Items.FindByValue(Request.Cookies["currency"].Value).Selected = true;
                }
                catch (Exception ex)
                {
                    ExHelper.HandleException(ex);
                }

                ApiAuthRepository apiRepo = new ApiAuthRepository();
                if (User.Identity.IsAuthenticated)
                {
                    var ApiMod = apiRepo.GetApiUserByUserID(User.Identity.GetUserId());
                    if (ApiMod != null)
                    {
                        PublicApiKey.Text = ApiMod.PublicKey;
                        PrivateApiKey.Text = ApiMod.PrivateKey;
                    }
                    else
                    {
                        PublicApiKey.Text = "";
                        PrivateApiKey.Text = "";
                    }
                }
            }
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // Remove phonenumber from user
        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = manager.SetPhoneNumber(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return;
            }
            var user = manager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }

        // DisableTwoFactorAuthentication
        protected void TwoFactorDisable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), false);

            Response.Redirect("/Account/Manage");
        }

        //EnableTwoFactorAuthentication 
        protected void TwoFactorEnable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), true);

            Response.Redirect("/Account/Manage");
        }

        protected void CurrencyDropDown_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //Write coockie with default currency
            HttpCookie currencyCookie = new HttpCookie("currency");
            currencyCookie.Value = CurrencyDropDown.SelectedItem.Value;
            currencyCookie.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(currencyCookie);
        }

        protected void LanguageDropDown_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //Write cookie with default lang
            HttpCookie langCookie = new HttpCookie("lang");
            langCookie.Value = LanguageDropDown.SelectedItem.Value;
            langCookie.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(langCookie);
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Request.Cookies["lang"].Value);
        }

        protected void GenerateNewPairOfKeysButton_OnClick(object sender, EventArgs e)
        {
            ApiAuthRepository apiRepo = new ApiAuthRepository();
            if (User.Identity.IsAuthenticated)
            {
                var ApiMod = apiRepo.GetApiUserByUserID(User.Identity.GetUserId());
                if (ApiMod != null)
                {
                    ApiMod.PrivateKey = Guid.NewGuid().ToString();
                    ApiMod.PublicKey = Guid.NewGuid().ToString();
                    apiRepo.UpdateApiUser(ApiMod);
                    apiRepo.Save();
                    
                }
                else
                {
                    ApiUser apiU = new ApiUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        PrivateKey = Guid.NewGuid().ToString(),
                        PublicKey = Guid.NewGuid().ToString(),
                        UserId = User.Identity.GetUserId(),
                    };
                    apiRepo.InsertUser(apiU);
                    apiRepo.Save();
                }
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}