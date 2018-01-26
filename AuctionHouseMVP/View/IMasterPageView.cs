using System.Collections.Generic;
using AHWForm.Models;

namespace AHWForm.View
{
    public interface IMasterPageView
    {
        IEnumerable<CategoryModel> tv { get; set; }
    }
}