using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Helper;
using AHWForm.Models.Comments;

namespace AHWForm
{
    public partial class CommentSite : Page, ICommentsView
    {
        private UserCommentListPresenter p;
        public List<CommentsBuyView> vm { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                p = new UserCommentListPresenter(new UserBuyCommentsModel(), this);
                p.PopulateCommentList();
                CommentList.DataSource = vm;
                CommentList.DataBind();
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