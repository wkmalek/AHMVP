using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using Repositories;
using Repositories.Context;

namespace AHWForm.Repos
{
    public class CategoryRepository :AbstractDbRepostiory<CategoryModel>, ICategoryRepository<CategoryModel>
    {
        public IEnumerable<CategoryModel> GetCategoriesWithChilds(string id)
        {
            Connect();
            //returns list of categories with their childrens
            if (id == null)
            {
                var outp = GetAllElements();
                context.Dispose();
                return outp;
            }
            CategoryModel cat = GetSingleElementByID(id);
            List<CategoryModel> list = new List<CategoryModel>();
            list.Add(cat);
            var output = FindAllChildrens(list, cat.Id);
            context.Dispose();
            return output;
        }

        private List<CategoryModel> FindAllChildrens(List<CategoryModel> categoryList, string parentId)
        {
            List<CategoryModel> catList = GetAllElements().ToList();
            
            foreach (var item in catList)
            {
                if (item.ParentCategoryId == parentId)
                {
                    categoryList.Add(item);
                    categoryList.AddRange(FindAllChildrens(categoryList, item.Id));
                }
            }
            return categoryList;
        }

        ~CategoryRepository()
        {
            Dispose(false);
        }
    }
}