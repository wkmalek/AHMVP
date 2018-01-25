using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(id).UserName;
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return "";
            }

            
        }

        public static string GetCurrentUser()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }
    }
}