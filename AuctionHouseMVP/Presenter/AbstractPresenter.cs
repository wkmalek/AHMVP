using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using AHWForm.Models;
using AHWForm.View;

namespace AHWForm.Presenter
{
    public abstract class AbstractPresenter<TView> where TView : IMyView 
    {
        protected internal TView _pView { get; set; }
    }
}