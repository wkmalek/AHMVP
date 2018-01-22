using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Models.Comments;
using AHWForm.Presenter;
using AHWForm.View;

namespace AHWForm
{
    public partial class CreateComment : System.Web.UI.Page, ICreateCommentView
    {
        public string Description { get; set; }
        public string Rate { get; set; }

        public CreateCommentPresenter p;

        protected void Page_Load(object sender, EventArgs e)
        {
            p= new CreateCommentPresenter(new UserBuyCommentsModel(), this);
            if (!Page.IsPostBack)
            {
                CreateCommentRate.Items.AddRange(new ListItem[] 
                {
                    new ListItem("1"),
                    new ListItem("2"),
                    new ListItem("3"),
                    new ListItem("4"),
                    new ListItem("5"),
                });
            }
        }

        protected void PassNewAuctionButton_OnClick(object sender, EventArgs e)
        {
            Description = DescriptionTextBox.Text;
            Rate = CreateCommentRate.SelectedItem.Value;
            p.CreateNewComment(Description,Rate);

        }


    }
}