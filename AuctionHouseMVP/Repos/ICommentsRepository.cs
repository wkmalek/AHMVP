using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHWForm.Models;

namespace AHWForm.Repos
{
    public interface ICommentsRepository
    {
        IEnumerable<CommentsModel> GetComments();
        IEnumerable<CommentsModel> GetBuyCommentsByUserID(string ID);
        IEnumerable<CommentsModel> GetSellCommentsByUserID(string ID);
        CommentsModel GetSingleCommentByID(string ID);
        void InsertComment(CommentsModel model);
        void UpdateComment(CommentsModel model);
        void Save();
        
    }
}

