using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHWForm.View
{
    public interface IAuctionDetailsView
    {
        string AuctionTitle { get; set; }
        string ShortDescription { get; set; }
        string LongDescription { get; set; }
        string Price { get; set; }
        string CreatorName { get; set; }
        string DateCreated { get; set; }

    }
}
