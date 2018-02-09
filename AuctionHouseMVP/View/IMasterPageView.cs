using System.Collections.Generic;
using AHWForm.Models;

namespace AHWForm.View
{
    public interface IMasterPageView:IMVPView
    {
        IEnumerable<CategoryModel> tv { get; set; }
    }
}