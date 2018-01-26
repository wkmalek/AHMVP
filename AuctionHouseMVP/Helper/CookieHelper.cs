using System.Web;

namespace AHWForm.Helper
{
    public static class CookieHelper
    {
        public static string CheckCookie(string name, string defaultValue)
        {
            var cookie = HttpContext.Current.Request.Cookies[name];
            return cookie != null ? cookie.Value : defaultValue;
        }
    }
}