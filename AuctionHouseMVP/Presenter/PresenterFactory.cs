using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using AHWForm.View;

namespace AHWForm.Presenter
{
    public static class PresenterFactory
    {
        public static IPresenter GetPresenter<T>(MyPage<T> view) where T : IPresenter, new()
        {
            // presenter[model,view]
            var viewType = view.GetType();
            //return new T(T);
            object[] args = new object[]
            {
                viewType,
            };
            return new T();
        }
    }
}