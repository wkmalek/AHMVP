using AHWForm.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Classes_And_Interfaces;
using AHWForm.ExtMethods;
using AHWForm.Models.Comments;
using AHWForm.Presenter;

namespace AHWForm
{
    public partial class CommentSite : System.Web.UI.Page, IExtensionMethods, ICommentsView
    {
        public List<CommentsBuyView> vm { get; set; }
        private UserCommentListPresenter p;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { 
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
                UrlHelper.RedirectToWriteComment((string)commandArg);
            }
        }
    }
}