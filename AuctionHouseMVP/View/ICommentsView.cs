using System.Collections.Generic;
using AHWForm.Models.Comments;
using AHWForm.View;

namespace AHWForm
{
    public interface ICommentsView : IMyView
    {
        List<CommentsBuyView> vm { get; set; }
    }
}