using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.UI;
using AHWForm.Models;
using AHWForm.Presenter;

namespace AHWForm.View
{
    public abstract class ViewBasePage<TPresenter, TMyView>:Page
        where TPresenter : AbstractPresenter<TMyView>, new()
        where TMyView : IMyView
    {
        protected TPresenter _presenter;

        public TPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter._pView = GetView();
            }
        }

        private static TMyView GetView()
        {
            return (TMyView) HttpContext.Current.Handler;
        }

        protected override void OnPreInit(EventArgs e)
        {
            Presenter = new TPresenter();
            base.OnPreInit(e);
            InitializeCulture();
        }

    }
}