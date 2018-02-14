using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Helper;
using AHWForm.Models.Auctions.CreateAuction;
using AHWForm.View;
using NUnit.Framework;

namespace AHWForm.Presenter
{
    public class CreateAuctionPresenter : AbstractPresenter<ICreateAuctionView>
    {
        private readonly ICreateAuctionModel _pModel = new CreateAuctionModel();


        internal void CreateAuction()
        {
            var fileId = (List<string>) HttpContext.Current.Session["ListOfImages"];
            CreateAuctionViewModel vm = new CreateAuctionViewModel
            {
                AuctionTitle = _pView.AuctionTitle,
                ActualPrice = _pView.ActualPrice,
                ExpiresIn = int.Parse(_pView.ExpiresIn),
                ShortDescription = _pView.ShortDescription,
                LongDescription = _pView.LongDescription,
                CategoryId = _pView.CategoryId,
                ImageGuid = fileId,
                Currency = _pView.Currency,
            };

            if (_pModel.CreateAuction(vm))
                UrlHelper.Redirect("~/AuctionDetails?Id=" + _pModel.Id);
            else
                throw new HttpException(404, "Auction create failed");
        }

        internal void Populate()
        {
            HttpContext.Current.Session["ListOfImages"] = _pView.ImageGuid;
            _pView.tv = _pModel.LoadCategories();
        }

        internal void AddFile()
        {
            if (_pView.file.HasFile)
            {
                string ext = Path.GetExtension(_pView.file.PostedFile.FileName);
                string name = Guid.NewGuid().ToString();
                _pView.file.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("~/Images/") + name + ext);
                _pView.ImageGuid = (List<string>)HttpContext.Current.Session["ListOfImages"];
                _pView.ImageGuid.Add(name + ext);
                HttpContext.Current.Session["ListOfImages"] = _pView.ImageGuid;
            }
        }
    }
}