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
            return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(id).UserName;
        }

        public static string GetCurrentUser()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }
    }
}