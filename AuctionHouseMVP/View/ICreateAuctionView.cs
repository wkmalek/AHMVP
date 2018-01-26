using System.Collections.Generic;
using AHWForm.Models;

namespace AHWForm.View
{
    public interface ICreateAuctionView
    {
        IEnumerable<CategoryModel> tv { get; set; }
    }
}