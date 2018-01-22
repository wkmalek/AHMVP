using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Classes_And_Interfaces;
using AHWForm.Models;
using AHWForm.View;

namespace AHWForm.Presenter
{
    public class CreateCommentPresenter
    {
        private ICreateCommentView _pView;
        private ICommentsModel _pModel;

        public CreateCommentPresenter(ICommentsModel PModel, ICreateCommentView PView)
        {
            _pView = PView;
            _pModel = PModel;
        }

        internal void CreateNewComment(string desc, string rate)
        {
            var qs = UrlHelper.GetQueryString("Id");
            var id = UrlHelper.GetSpecificQueryFromDict("Id", qs);
            _pModel.CreateComment(desc,rate, id);
            UrlHelper.Redirect(UrlHelper.GetUrlForUserSite(id));
        }
    }
}