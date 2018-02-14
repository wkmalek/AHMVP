using System.Collections.Generic;
using AHWForm.Models;
using AHWForm.View;

namespace AHWForm.Presenter
{
    public interface IAuctionListView : IMyView
    {
        List<AuctionListSingleElemVM> vm { get; set; }
    }
}