﻿using AHWForm.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Classes_And_Interfaces;
using AHWForm.ExtMethods;
using AHWForm.Presenter;

namespace AHWForm
{
    public partial class CommentSite : System.Web.UI.Page, IExtensionMethods, ICommentsView
    {
        public List<CommentsView> vm { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserCommentListPresenter p = new UserCommentListPresenter(new CommentsModel(), this);
            p.PopulateCommentList();
            CommentList.DataSource = vm;
            CommentList.DataBind();

        }

        //private void fetchData(List<CommentsView> comments)
        //{
        //    CommentList.DataSource = comments;
        //    CommentList.DataBind();
        //}

        //private List<CommentsView> GetComments(string id)
        //{
        //        CommentsContext commentsContext = new CommentsContext();
        //        IQueryable<CommentsModel> query =  commentsContext.Comment.Where(x => x.SellerId == id);
        //        List<CommentsModel> commentsList = query.ToList();
        //        //Builds container that have comment information after converting to userfriendly format
        //        List<CommentsView> commentsView = new List<CommentsView>();
        //        foreach(CommentsModel item in commentsList)
        //        {      
        //            CommentsView row = new CommentsView();
        //            row.AuctionUrl = "AuctionDetails.aspx?Id=" + item.AuctionId;
        //            AuctionModel auction = ExtensionMethods.GetAuction(item.AuctionId);
        //            row.AuctionTitle = ExtensionMethods.GetAuction(item.AuctionId).Title;
        //            row.BuyerUrl = "CommentSite.aspx?Id=" + item.BuyerId;
        //            row.SellerUrl = "CommentSite.aspx?Id=" + item.SellerId;
        //            row.Description = item.Description;
        //            row.Rate = item.Rate;
        //            row.SellerName = ExtensionMethods.GetUserNameByID(item.SellerId);
        //            row.BuyerName = ExtensionMethods.GetUserNameByID(item.BuyerId);
        //            commentsView.Add(row);
        //        }
        //        return commentsView;
        //}
       
    }
}