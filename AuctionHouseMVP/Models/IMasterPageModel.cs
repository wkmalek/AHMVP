using AHWForm.Models;
using System.Collections.Generic;

namespace AHWForm.Presenter
{
    public interface IMasterPageModel
    {
        IEnumerable<CategoryModel> LoadCategories();
    }
}