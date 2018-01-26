using System;
using System.Collections.Generic;
using AHWForm.Models.Images;
using AHWForm.Repos;
using Elmah;
using Repositories;

namespace AHWForm.Models.Auctions.CreateAuction
{
    public class CreateAuctionModel : ICreateAuctionModel
    {
        public CreateAuctionModel()
        {
            auctionRepo = RepositoryFactory.GetRepositoryInstance<AuctionModel, AuctionsRepository>();
            catRepo = RepositoryFactory.GetRepositoryInstance<CategoryModel, CategoryRepository>();
            imageRepo = RepositoryFactory.GetRepositoryInstance<ImagesModel, ImageRepository>();
        }

        private IAuctionsRepository<AuctionModel> auctionRepo { get; set; }
        private ICategoryRepository<CategoryModel> catRepo { get; set; }
        private IImageRepository<ImagesModel> imageRepo { get; set; }
        public string Id { get; private set; }

        public bool CreateAuction(CreateAuctionViewModel auc)
        {
            try
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
                return true;
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }
        }

        public IEnumerable<CategoryModel> LoadCategories()
        {
            return catRepo.GetAllElements();
        }
    }
}