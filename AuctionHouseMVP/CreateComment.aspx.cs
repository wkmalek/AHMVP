using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Models.Comments;
using AHWForm.Presenter;
using AHWForm.View;

namespace AHWForm
{
    public partial class CreateComment : ViewBasePage<CreateCommentPresenter, ICreateCommentView>, ICreateCommentView
    {
        private static readonly int maxRate = 5;

        public string Description
        {
            get { return DescriptionTextBox.Text;}
            set { DescriptionTextBox.Text = value; }
        }

        public string Rate
        {
            get { return CreateCommentRate.SelectedItem.Value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var listItem = new ListItem[maxRate];

                for (int i = 1; i <= maxRate; i++)
                {
                    listItem[i - 1] = new ListItem(i.ToString());
                }

                CreateCommentRate.Items.AddRange(listItem);
            }
        }

        protected void PassNewAuctionButton_OnClick(object sender, EventArgs e)
        {
            _presenter.CreateNewComment(Description, Rate);
        }
    }
}