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
            //var vm = _pModel.LoadComments(HttpContext.Current.Request.QueryString["Id"]);
            var vm = _pModel.LoadComments("03c58d0b-7548-44cf-807b-561884180bb6");
            _pView.vm = vm;
        }
    }
}