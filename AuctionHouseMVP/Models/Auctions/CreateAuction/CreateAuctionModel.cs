using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using AHWForm.Repos;

namespace AHWForm.Models.Auctions.CreateAuction
{ 
    public class CreateAuctionModel : ICreateAuctionModel
    {
        private IAuctionsRepository auctionRepo { get; set; }
        private ICategoryRepository catRepo { get; set; }
        public string Id { get; set; }

        public CreateAuctionModel()
        {
            auctionRepo = new AuctionsRepository(new AuctionContext());
            catRepo = new CategoryRepository(new CategoryContext());
        }

        public void CreateAuction(CreateAuctionViewModel auc)
        {
            var temp = auc.GetModel();
            auctionRepo.InsertAuction(temp);
            
            auctionRepo.Save();
            Id = temp.Id;
        }

        public IEnumerable<CategoryModel> LoadCategories()
        {
            return catRepo.GetCategories();
        }
    }
}