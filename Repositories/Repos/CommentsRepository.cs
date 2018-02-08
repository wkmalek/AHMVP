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
    public class CommentsRepository:AbstractRepostiory<CommentsModel>, ICommentsRepository<CommentsModel>
    {

        public CommentsRepository()
        {
            context = new GenericContextFactory<CommentsModel>("CommentsContext");
        }

        public IEnumerable<CommentsModel> GetBuyCommentsByUserID(string ID)
        {
            return context.dbSet.Where(x => x.BuyerId == ID).ToList();
        }

        public IEnumerable<CommentsModel> GetSellCommentsByUserID(string ID)
        {
            return context.dbSet.Where(x => x.SellerId == ID).ToList();
        }

        ~CommentsRepository()
        {
            Dispose(false);
        }
    }
}