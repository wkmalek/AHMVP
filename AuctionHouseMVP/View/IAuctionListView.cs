using System.Collections.Generic;
using AHWForm.Models;
using AHWForm.View;

namespace AHWForm.Presenter
{
    public interface IAuctionListView : IMVPView
    {
        List<AuctionListSingleElemVM> vm { get; set; }
    }
}