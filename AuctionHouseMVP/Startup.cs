using System;
using System.Web;
using System.Web.Caching;
using AHWForm;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace AHWForm
{
    public partial class Startup
    {
        private static CacheItemRemovedCallback OnCacheRemove;


        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AddTask("RefreshAuctions", 1);
        }

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        private void AddTask(string name, int seconds)
        {
            OnCacheRemove = CacheItemRemoved;
            HttpRuntime.Cache.Insert(name, seconds, null,
                DateTime.Now.AddSeconds(seconds), Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable, OnCacheRemove);
        }

        public void CacheItemRemoved(string k, object v, CacheItemRemovedReason r)
        {
            if (k == "RefreshAuctions")
            {
                //RefreshDB();

                AddTask(k, Convert.ToInt32(v));
            }
        }
    }
}