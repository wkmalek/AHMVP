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
    public class ImageRepository: AbstractDbRepostiory<ImagesModel>, IImageRepository<ImagesModel>
    { 
        public IEnumerable<ImagesModel> GetImagesByUserID(string ID)
        {
            Connect();
            var output = context.dbSet.Where(x => x.UserID == ID).ToList();
            context.Dispose();
            return output;
        }

        public IEnumerable<ImagesModel> GetImagesByAuctionID(string ID)
        {
            Connect();
            var output = context.dbSet.Where(x => x.AuctionID == ID).ToList();
            context.Dispose();
            return output;
        }

        ~ImageRepository()
        {
            Dispose(false);
        }
    }
}