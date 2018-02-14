using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Helper;
using AHWForm.Models.Comments;
using AHWForm.View;

namespace AHWForm
{
    public partial class CommentSite : ViewBasePage<UserCommentListPresenter,ICommentsView>, ICommentsView
    {
        private List<CommentsBuyView> _vm;
        public List<CommentsBuyView> vm
        {
            get { return _vm; }
            set
            {
                _vm = value;
                CommentList.DataSource = vm;
                CommentList.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presenter.PopulateCommentList();
            }
        }

        protected void CommentList_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Go")
            {
                object commandArg = e.CommandArgument;
                UrlHelper.RedirectToWriteComment((string) commandArg);
            }
        }
    }
}