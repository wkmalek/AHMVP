using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using AHWForm.Models.Images;
using AHWForm.Repos;
using Repositories;

namespace AHWForm.Models.Auctions.CreateAuction
{ 
    public class CreateAuctionModel : ICreateAuctionModel
    {
        private IAuctionsRepository<AuctionModel> auctionRepo { get; set; }
        private ICategoryRepository<CategoryModel> catRepo { get; set; }
        private IImageRepository<ImagesModel> imageRepo { get; set; }
        public string Id { get; set; }

        public CreateAuctionModel()
        {
            auctionRepo = RepositoryFactory.GetRepositoryInstance<AuctionModel, AuctionsRepository>();
            catRepo = RepositoryFactory.GetRepositoryInstance<CategoryModel, CategoryRepository>();
            imageRepo = RepositoryFactory.GetRepositoryInstance<ImagesModel, ImageRepository>();
        }

        public void CreateAuction(CreateAuctionViewModel auc)
        {
            List<ImagesModel> imagesModels;
            var temp = auc.GetModel(out imagesModels);

            auctionRepo.Insert(temp);
            foreach (var item in imagesModels)
            {
                imageRepo.Insert(item);   
            }

            imageRepo.Save();
            auctionRepo.Save();
            Id = temp.Id;
        }

        public IEnumerable<CategoryModel> LoadCategories()
        {
            return catRepo.GetAllElements();
        }
    }
}