using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using AHWForm.Models.Images;
using AHWForm.Repos;

namespace AHWForm.Models.Auctions.CreateAuction
{ 
    public class CreateAuctionModel : ICreateAuctionModel
    {
        private IAuctionsRepository auctionRepo { get; set; }
        private ICategoryRepository catRepo { get; set; }
        private IImageRepository imageRepo { get; set; }
        public string Id { get; set; }

        public CreateAuctionModel()
        {
            auctionRepo = new AuctionsRepository();
            catRepo = new CategoryRepository(new CategoryContext());
            imageRepo = new ImageRepository();
        }

        public void CreateAuction(CreateAuctionViewModel auc)
        {
            List<ImagesModel> imagesModels;
            var temp = auc.GetModel(out imagesModels);

            auctionRepo.InsertAuction(temp);
            foreach (var item in imagesModels)
            {
                imageRepo.InsertImage(item);   
            }

            imageRepo.Save();
            auctionRepo.Save();
            Id = temp.Id;
        }

        public IEnumerable<CategoryModel> LoadCategories()
        {
            return catRepo.GetCategories();
        }
    }
}