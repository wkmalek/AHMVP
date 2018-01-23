using System.Collections.Generic;
using AHWForm.Models.Images;

namespace AHWForm.Repos
{
    public interface IImageRepository
    {
        IEnumerable<ImagesModel> GetImages();
        IEnumerable<ImagesModel> GetImagesByUserID(string ID);
        IEnumerable<ImagesModel> GetImagesByAuctionID(string ID);
        ImagesModel GetImageByID(string ID);
        void InsertImage(ImagesModel model);
        void UpdateImage(ImagesModel model);
        void Save();
    }
}