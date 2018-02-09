using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using AHWForm.View;

namespace AHWForm.Presenter
{
    public abstract class AbstractPresenter<T,U> : IPresenter where T : IModel where U : IMVPView
    {
        internal readonly T _pModel;
        internal readonly U _pView;

        protected AbstractPresenter(T PModel, U PView)
        {
            _pView = PView;
            _pModel = PModel;
        }
    }
}
