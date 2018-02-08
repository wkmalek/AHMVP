using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using Repositories;
using Repositories.Context;

namespace AHWForm.Repos
{
    public class CategoryRepository :AbstractRepostiory<CategoryModel>, ICategoryRepository<CategoryModel>
    {
        public CategoryRepository()
        {
            context = new GenericContextFactory<CategoryModel>("CategoryContext");
        }

        public IEnumerable<CategoryModel> GetCategoriesWithChilds(string id)
        {
            //returns list of categories with their childrens
            if (id == null)
               return GetAllElements();
            CategoryModel cat = GetSingleElementByID(id);
            List<CategoryModel> list = new List<CategoryModel>();
            list.Add(cat);
            return FindAllChildrens(list, cat.Id);    
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