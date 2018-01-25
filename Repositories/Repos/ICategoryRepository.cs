using AHWForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHWForm.Repos
{
    public interface ICategoryRepository<T>:IRepository<T> where T: class
    {
        IEnumerable<T> GetCategoriesWithChilds(string ID);
    }
}
