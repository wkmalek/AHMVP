using System;
using System.Collections.Generic;
using System.Linq;
using AHWForm.Repos;
using Elmah;
using Repositories;

namespace AHWForm.Models.Comments
{
    public class UserBuyCommentsModel : ICommentsModel
    {
        private readonly AuctionsRepository auctionRepo =
            RepositoryFactory.GetRepositoryInstance<AuctionModel, AuctionsRepository>();

        private readonly CommentsRepository commentsRepo =
            RepositoryFactory.GetRepositoryInstance<CommentsModel, CommentsRepository>();

        public List<CommentsBuyView> LoadComments(string v)
        {
            //TODO
            var auctions = auctionRepo.GetAuctionByUserID(v);
            var comments = LoadBuyerCommentsModel(v);
            var output = new List<CommentsBuyView>();

            foreach (var auc in auctions)
            {
                if (string.IsNullOrEmpty(auc.WinnerId)) continue;
                CommentsBuyView com;
                var comment = comments.FirstOrDefault(x => x.BuyerId == auc.WinnerId && x.AuctionId == auc.Id);
                if (comment != null)
                {
                    com = new CommentsBuyView(comment, false);
                }
                else
                {
                    com = new CommentsBuyView(new CommentsModel
                    {
                        BuyerId = auc.WinnerId,
                        AuctionId = auc.Id,
                        Description = "",
                        Id = null,
                        SellerId = auc.CreatorId
                    }, true);
                }

                output.Add(com);
            }
            return output;
        }

        public bool CreateComment(string rate, string desc, string ID)
        {
            try
            {
                var auction = auctionRepo.GetSingleElementByID(ID);
                var comment = new CommentsModel
                {
                    Rate = int.Parse(rate),
                    Description = desc,
                    Id = Guid.NewGuid().ToString(),
                    AuctionId = auction.Id,
                    BuyerId = auction.WinnerId,
                    SellerId = auction.CategoryId
                };
                commentsRepo.Insert(comment);
                commentsRepo.Save();
                return true;
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }
        }

        private List<CommentsModel> LoadBuyerCommentsModel(string v)
        {
            return commentsRepo.GetBuyCommentsByUserID(v).ToList();
        }

        ~UserBuyCommentsModel()
        {
            auctionRepo.Dispose();
            commentsRepo.Dispose();
        }
    }
}