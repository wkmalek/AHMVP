using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AHWForm.Models;
using AHWForm.Models.Images;
using Repositories;
using Repositories.Context;

namespace AHWForm.Repos
{
    public class ImageRepository: AbstractRepostiory<ImagesModel>, IImageRepository<ImagesModel>
    { 
        public ImageRepository()
        {
            context = new GenericContextFactory<ImagesModel>("ImagesContext");
        }

        public IEnumerable<ImagesModel> GetImagesByUserID(string ID)
        {
            return context.dbSet.Where(x => x.UserID == ID);
        }

        public IEnumerable<ImagesModel> GetImagesByAuctionID(string ID)
        {
            return context.dbSet.Where(x => x.AuctionID == ID);
        }

        ~ImageRepository()
        {
            Dispose(false);
        }
    }
}