using System.Collections.Generic;
using AHWForm.Models.Comments;
using AHWForm.View;

namespace AHWForm
{
    internal interface ICommentsView : IMVPView
    {
        List<CommentsBuyView> vm { get; set; }
    }
}