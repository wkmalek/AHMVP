using System.Collections.Generic;
using AHWForm.Models.Comments;

namespace AHWForm
{
    public interface ICommentsModel
    {
        List<CommentsBuyView> LoadComments(string v);
        bool CreateComment(string desc, string rate, string ID);
    }
}