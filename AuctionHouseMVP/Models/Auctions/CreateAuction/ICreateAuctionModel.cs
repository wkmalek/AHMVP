using System.Collections.Generic;

namespace AHWForm.Models.Auctions.CreateAuction
{
    public interface ICreateAuctionModel
    {
        string Id { get; }
        bool CreateAuction(CreateAuctionViewModel auc);
        IEnumerable<CategoryModel> LoadCategories();
    }
}