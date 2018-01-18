using AHWForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHWForm.Repos
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryModel> GetCategories();
        IEnumerable<CategoryModel> GetCategoriesWithChilds(string ID);
        CategoryModel GetSingleCategory(string ID);  
    }
}
