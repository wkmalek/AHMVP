using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Models.Comments;
using AHWForm.Presenter;
using AHWForm.View;

namespace AHWForm
{
    public partial class CreateComment : Page, ICreateCommentView
    {
        private static readonly int maxRate = 5;

        public CreateCommentPresenter p;

        public string Description { get; set; }
        public string Rate { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            p = new CreateCommentPresenter(new UserBuyCommentsModel(), this);
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
            Description = DescriptionTextBox.Text;
            Rate = CreateCommentRate.SelectedItem.Value;
            p.CreateNewComment(Description, Rate);
        }
    }
}