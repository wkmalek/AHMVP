using System.Collections.Generic;
using AHWForm.Models;

namespace AHWForm.Presenter
{
    public interface IAuctionListModel
    {
        AuctionListViewModel LoadAuctions(string ID, string currency);
    }
}