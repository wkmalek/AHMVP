using System;
using System.Web;
using Elmah;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace AHWForm.ExtMethods
{
    public static class UserHelper
    {
        public static string GetUserNameById(string id)
        {
            try
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(id)
                    .UserName;
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return "";
            }
        }

        public static string GetCurrentUser()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }
    }
}