using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using AHWForm.Models;

namespace AHWForm.Helper
{
    public static class UrlHelper
    {
        public static Dictionary<string, string> GetQueryString(params string[] qs)
        {
            Dictionary<string, string> output = new Dictionary<string, string>();
            foreach (var item in qs)
            {
                output.Add(item, HttpContext.Current.Request.QueryString[item]);
            }

            return output;
        }

        public static string GetQueryString(string key)
        {
            return HttpContext.Current.Request.QueryString[key];
        }

        public static string MakeQueryString(Dictionary<string, string> qs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("?");
            if (qs?.Count > 0)
            {
                foreach (var item in qs)
                {
                    sb.Append(item.Key);
                    sb.Append("=");
                    sb.Append(item.Value);
                    sb.Append("&");
                }

                return sb.ToString();
            }

            return "";
        }

        public static string GetSpecificQueryFromDict(string key, Dictionary<string, string> dict)
        {
            return dict.FirstOrDefault(x => x.Key == key).Value;
        }


        public static string GetUrlForUserSite(string ID)
        {
            return "~/CommentSite?Id=" + ID;
        }

        internal static string GetUrlForWriteComment(CommentsModel model)
        {
            Dictionary<string, string> url = new Dictionary<string, string>
            {
                {"Id", model.AuctionId}
            };
            return MakeQueryString(url);
        }

        public static string GetUrlForAuction(string ID)
        {
            return "~/AuctionDetails?Id=" + ID;
        }

        public static void Redirect(string link)
        {
            HttpContext.Current.Response.Redirect(link);
        }

        public static void RedirectToAuction(string ID)
        {
            Redirect(GetUrlForAuction(ID));
        }

        public static void RedirectToWriteComment(string link)
        {
            Redirect("~/CreateComment" + link);
        }
    }
}