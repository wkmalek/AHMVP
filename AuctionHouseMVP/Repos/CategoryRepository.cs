using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;

namespace AHWForm.Repos
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private CategoryContext context;
        
        public CategoryRepository(CategoryContext context)
        {
            this.context = context;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            return context.Categories.ToList();
        }

        public IEnumerable<CategoryModel> GetCategoriesWithChilds(string id)
        {
            //returns list of categories with their childrens
            CategoryModel cat = GetSingleCategory(id);
            List<CategoryModel> list = new List<CategoryModel>();
            list.Add(cat);
            return FindAllChildrens(list, cat, cat.Id);    
        }

        private List<CategoryModel> FindAllChildrens(List<CategoryModel> categoryList, CategoryModel cat, string parentId)
        {
            List<CategoryModel> catList = GetCategories().ToList();
            
            foreach (var item in catList)
            {
                if (item.ParentCategoryId == parentId)
                {
                    categoryList.Add(item);
                    categoryList.AddRange(FindAllChildrens(categoryList, cat, item.Id));
                }
            }
            return categoryList;
        }

        public CategoryModel GetSingleCategory(string ID)
        {
            return context.Categories.Find(ID);
        }



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}