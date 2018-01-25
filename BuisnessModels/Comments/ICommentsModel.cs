using System.Collections.Generic;
using AHWForm.Models;
using AHWForm.Models.Comments;

namespace AHWForm
{
    public interface ICommentsModel
    {
        List<CommentsBuyView> LoadComments(string v);
        void CreateComment(string desc, string rate, string ID);
    }
}