using AHWForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHWForm.Repos
{
    public interface IAuctionsRepository<T>:IRepository<T> where T: class
    {
        IEnumerable<T> GetAuctionsByCatList(IEnumerable<CategoryModel> cat);
        IEnumerable<T> GetAuctionByUserID(string ID);
        bool CheckIfAuctionEnded(string ID);
        bool CheckIfEndingPriceIsOk(BidsModel bid);
    }
}