using System.Collections.Generic;
using AHWForm.Models.Images;

namespace AHWForm.Repos
{
    public interface IImageRepository<T>:IRepository<T> where T:class
    {
        IEnumerable<T> GetImagesByUserID(string ID);
        IEnumerable<T> GetImagesByAuctionID(string ID);
    }
}