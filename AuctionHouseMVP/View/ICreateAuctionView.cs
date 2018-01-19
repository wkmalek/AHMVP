using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;

namespace AHWForm.View
{
    public interface ICreateAuctionView
    {
        IEnumerable<CategoryModel> tv { get; set; }
    }
}