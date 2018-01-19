using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace AHWForm.Classes_And_Interfaces
{
    public static class UrlHelper
    {
        public static Dictionary<string, string> GetQueryString(params string[] qs)
        {
            Dictionary<string,string> output = new Dictionary<string, string>();
            foreach (var item in qs)
            {
                output.Add(item, HttpContext.Current.Request.QueryString[item]);
            }
            return output;
        }

        
    }
}