using System.Collections.Generic;
using AHWForm.Models.Comments;

namespace AHWForm
{
    internal interface ICommentsView
    {
        List<CommentsBuyView> vm { get; set; }
    }
}