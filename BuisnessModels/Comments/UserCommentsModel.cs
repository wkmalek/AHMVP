using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using AHWForm.Repos;
using Repositories;

namespace AHWForm.Models.Comments
{
    public class UserBuyCommentsModel : ICommentsModel
    {
        
        AuctionsRepository auctionRepo = RepositoryFactory.GetRepositoryInstance<AuctionModel, AuctionsRepository>();
        CommentsRepository commentsRepo = RepositoryFactory.GetRepositoryInstance<CommentsModel, CommentsRepository>();

        public List<CommentsBuyView> LoadComments(string v)
        {
            var auctions = auctionRepo.GetAuctionByUserID(v);
            var comments = LoadBuyerCommentsModel(v);
            List<CommentsBuyView> output = new List<CommentsBuyView>();

            foreach (var auc in auctions)
            {
                if (!String.IsNullOrEmpty(auc.WinnerId))
                {
                    CommentsBuyView com;
                    
                    var comment = comments.Where(x => x.BuyerId == auc.WinnerId && x.AuctionId == auc.Id).FirstOrDefault();

                    if (comment != null)
                    {
                        com = new CommentsBuyView(comment, false);
                    }
                    else
                    {
                        com = new CommentsBuyView(new CommentsModel()
                        {
                            BuyerId = auc.WinnerId,
                            AuctionId = auc.Id,
                            Description = "",
                            Id = null,
                            SellerId = auc.CreatorId,
                        }, true);
                    }
                    output.Add(com);
                }
            }

            return output;
        }

        private List<CommentsModel> LoadBuyerCommentsModel(string v)
        {
            return commentsRepo.GetBuyCommentsByUserID(v).ToList();
        }

        public void CreateComment(string rate, string desc, string ID)
        {
            var auction = auctionRepo.GetSingleElementByID(ID);
            CommentsModel comment = new CommentsModel()
            {
                Rate = Int32.Parse(rate),
                Description = desc,
                Id = Guid.NewGuid().ToString(),
                AuctionId = auction.Id,
                BuyerId = auction.WinnerId,
                SellerId = auction.CategoryId,
            };
            commentsRepo.Insert(comment);
            commentsRepo.Save();
        }
    }
}