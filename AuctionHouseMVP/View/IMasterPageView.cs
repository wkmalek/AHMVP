using AHWForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AHWForm.View
{
    public interface IMasterPageView
    {
        IEnumerable<CategoryModel> tv { get; set; }
    }
}