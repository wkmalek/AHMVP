using System.Web;
using AHWForm.Helper;
using AHWForm.View;

namespace AHWForm.Presenter
{
    public class CreateCommentPresenter
    {
        private readonly ICommentsModel _pModel;
        private ICreateCommentView _pView;

        public CreateCommentPresenter(ICommentsModel PModel, ICreateCommentView PView)
        {
            _pView = PView;
            _pModel = PModel;
        }

        internal void CreateNewComment(string desc, string rate)
        {
            var qs = UrlHelper.GetQueryString("Id");
            if (_pModel.CreateComment(desc, rate, qs))
                UrlHelper.Redirect(UrlHelper.GetUrlForUserSite(qs));
            else
                throw new HttpException(404, "Comments create failed");
        }
    }
}