using AHWForm.ExtMethods;
using AHWForm.Helper;
using AHWForm.Models.Comments;
using AHWForm.Presenter;

namespace AHWForm
{
    public class UserCommentListPresenter:AbstractPresenter<ICommentsView>
    {
        readonly ICommentsModel _pModel = new UserBuyCommentsModel();

        internal void PopulateCommentList()
        {
            var qs = UrlHelper.GetQueryString("Id");
            if (string.IsNullOrEmpty(qs) && UserHelper.IsUserLoggedIn())
            {
                qs = UserHelper.GetCurrentUser();
            }
            var vm = _pModel.LoadComments(qs);
            _pView.vm = vm;
        }
    }
}