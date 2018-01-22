using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AHWForm.Models;
using AHWForm.Models.Comments;

namespace AHWForm.Repos
{
    public class CommentsRepository: ICommentsRepository, IDisposable
    {
        public class CommentsContext : DbContext
        {
            public CommentsContext() : base("name=CommentsContext")
            {

            }
            public DbSet<CommentsModel> Comments { get; set; }
        }

        private CommentsContext context { get; set; }
        public CommentsRepository()
        {
            context = new CommentsContext();
        }

        public IEnumerable<CommentsModel> GetComments()
        {
            return context.Comments.ToList();
        }

        public IEnumerable<CommentsModel> GetBuyCommentsByUserID(string ID)
        {
            return context.Comments.Where(x => x.BuyerId == ID).ToList();
        }

        public IEnumerable<CommentsModel> GetSellCommentsByUserID(string ID)
        {
            return context.Comments.Where(x => x.SellerId == ID).ToList();
        }

        public CommentsModel GetSingleCommentByID(string ID)
        {
            return context.Comments.Find(ID);
        }

        public void InsertComment(CommentsModel model)
        {
            context.Comments.Add(model);
        }

        public void UpdateComment(CommentsModel model)
        {
            context.Entry(model).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}