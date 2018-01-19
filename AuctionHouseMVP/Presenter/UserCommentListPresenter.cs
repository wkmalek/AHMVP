using System;
using System.Web;
using AHWForm.Models;

namespace AHWForm
{
    internal class UserCommentListPresenter
    {
        ICommentsModel _pModel;
        ICommentsView _pView;

        public UserCommentListPresenter(ICommentsModel PModel, ICommentsView PView)
        {
            _pModel = PModel;
            _pView = PView;
        }

        internal void PopulateCommentList()
        {
            var vm = _pModel.LoadComments(HttpContext.Current.Request.QueryString["Id"]);
            _pView.vm = vm.List;
        }
    }
}