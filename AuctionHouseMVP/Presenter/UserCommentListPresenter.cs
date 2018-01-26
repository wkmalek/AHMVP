﻿using AHWForm.Helper;

namespace AHWForm
{
    internal class UserCommentListPresenter
    {
        readonly ICommentsModel _pModel;
        readonly ICommentsView _pView;

        public UserCommentListPresenter(ICommentsModel PModel, ICommentsView PView)
        {
            _pModel = PModel;
            _pView = PView;
        }

        internal void PopulateCommentList()
        {
            var qs = UrlHelper.GetQueryString("Id");
            var vm = _pModel.LoadComments(qs);
            _pView.vm = vm;
        }
    }
}