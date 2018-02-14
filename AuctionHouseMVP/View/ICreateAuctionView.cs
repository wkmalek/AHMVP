using System.Collections.Generic;
using System.Web.UI.WebControls;
using AHWForm.Models;

namespace AHWForm.View
{
    public interface ICreateAuctionView : IMyView
    {
        IEnumerable<CategoryModel> tv { set; }
        string AuctionTitle { get; set; }
        string ActualPrice { get; set; }
        string ExpiresIn { get; }
        string ShortDescription { get; set; }
        string LongDescription { get; set; }
        string CategoryId { get; }
        List<string> ImageGuid { get; set; }
        string Currency { get; }
        FileUpload file { get; set; }
    }
}