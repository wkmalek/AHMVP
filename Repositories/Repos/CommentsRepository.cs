using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AHWForm.Models;
using Repositories;
using Repositories.Context;

namespace AHWForm.Repos
{
    public class CommentsRepository:AbstractDbRepostiory<CommentsModel>, ICommentsRepository<CommentsModel>
    {

        public IEnumerable<CommentsModel> GetBuyCommentsByUserID(string ID)
        {
            Connect();
            var output = context.dbSet.Where(x => x.BuyerId == ID).ToList();
            context.Dispose();
            return output;
        }

        public IEnumerable<CommentsModel> GetSellCommentsByUserID(string ID)
        {
            Connect();
            var output = context.dbSet.Where(x => x.SellerId == ID).ToList();
            context.Dispose();
            return output;
        }

        ~CommentsRepository()
        {
            Dispose(false);
        }
    }
}