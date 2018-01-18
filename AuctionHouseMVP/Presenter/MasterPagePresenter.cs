using AHWForm.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHWForm.Presenter
{
    public class MasterPagePresenter
    {
        IMasterPageModel _pModel;
        IMasterPageView _pView;

        public MasterPagePresenter(IMasterPageModel PModel, IMasterPageView PView)
        {
            _pModel = PModel;
            _pView = PView;
        }

        internal void PopulateMasterPage()
        {
            _pView.tv = _pModel.LoadCategories();
        }

        
    }
}