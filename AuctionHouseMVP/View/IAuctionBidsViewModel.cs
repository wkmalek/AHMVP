﻿using AHWForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHWForm.View
{
    public interface IAuctionBidsViewModel
    {
        IList<AuctionBidViewModel> bidsViewModel {get;set;}
    }
}
