using AHWForm.Models;
using AHWForm.Repos;
using System;
using System.Collections.Generic;

namespace AHWForm.Presenter
{
    public class MasterPageViewModel : IMasterPageModel
    {
        private ICategoryRepository catRepo { get; set; }

        public MasterPageViewModel(ICategoryRepository catRepo)
        {
            this.catRepo = catRepo;
        }

        public IEnumerable<CategoryModel> LoadCategories()
        {
            return catRepo.GetCategories();
        }

        
    }
}