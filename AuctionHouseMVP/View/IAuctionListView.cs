using System.Collections.Generic;
using AHWForm.Models;

namespace AHWForm.Presenter
{
    public interface IAuctionListView
    {
        List<AuctionListSingleElemVM> vm { get; set; }
    }
}