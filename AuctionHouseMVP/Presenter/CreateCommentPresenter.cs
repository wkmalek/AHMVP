using System.Web;
using AHWForm.Helper;
using AHWForm.Models.Comments;
using AHWForm.View;

namespace AHWForm.Presenter
{
    public class CreateCommentPresenter:AbstractPresenter<ICreateCommentView>
    {
        private readonly ICommentsModel _pModel = new UserBuyCommentsModel();
       
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