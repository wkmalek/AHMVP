using System.Collections.Generic;
using AHWForm.Models;

namespace AHWForm.View
{
    public interface ICreateAuctionView : IMVPView
    {
        IEnumerable<CategoryModel> tv { get; set; }
    }
}