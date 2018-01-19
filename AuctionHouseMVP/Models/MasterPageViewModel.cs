using AHWForm.Models;
using AHWForm.Repos;
using System;
using System.Collections.Generic;

namespace AHWForm.Presenter
{
    public class MasterPageViewModel : IMasterPageModel
    {
        private ICategoryRepository catRepo { get; set; }

        public MasterPageViewModel()
        {
            this.catRepo = new CategoryRepository(new CategoryContext());
        }

        public IEnumerable<CategoryModel> LoadCategories()
        {
            return catRepo.GetCategories();
        }

        
    }
}