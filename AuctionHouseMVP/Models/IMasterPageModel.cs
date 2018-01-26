using System.Collections.Generic;
using AHWForm.Models;

namespace AHWForm.Presenter
{
    public interface IMasterPageModel
    {
        IEnumerable<CategoryModel> LoadCategories();
    }
}