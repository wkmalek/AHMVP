using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AHWForm.Models;
using AHWForm.Models.Images;

namespace AHWForm.Repos
{
    public class ImageRepository: IImageRepository, IDisposable
    {
        public class ImagesContext : DbContext
        {
            public ImagesContext() : base("name=ImagesContext")
            {

            }
            public DbSet<ImagesModel> ImagesModel { get; set; }
        }

        private ImagesContext context;

        public ImageRepository()
        {
            context = new ImagesContext();
        }

        

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ImagesModel> GetImages()
        {
            return context.ImagesModel.ToList();
        }

        public IEnumerable<ImagesModel> GetImagesByUserID(string ID)
        {
            return context.ImagesModel.Where(x => x.UserID == ID);
        }

        public IEnumerable<ImagesModel> GetImagesByAuctionID(string ID)
        {
            return context.ImagesModel.Where(x => x.AuctionID == ID);
        }

        public ImagesModel GetImageByID(string ID)
        {
            return context.ImagesModel.Find(ID);
        }

        public void InsertImage(ImagesModel model)
        {
            context.ImagesModel.Add(model);
        }

        public void UpdateImage(ImagesModel model)
        {
            context.Entry(model).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}