using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHWForm.Models.Auctions.CreateAuction
{
    public interface ICreateAuctionModel
    {
        void CreateAuction(CreateAuctionViewModel auc);
        IEnumerable<CategoryModel> LoadCategories();
        string Id { get; set; }
    }
}