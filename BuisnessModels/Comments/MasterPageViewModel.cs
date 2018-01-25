using AHWForm.Models;
using AHWForm.Repos;
using System;
using System.Collections.Generic;
using Repositories;

namespace AHWForm.Presenter
{
    public class MasterPageViewModel : IMasterPageModel
    {
        private CategoryRepository catRepo { get; set; }

        public MasterPageViewModel()
        {
            this.catRepo = RepositoryFactory.GetRepositoryInstance<CategoryModel, CategoryRepository>();
        }

        public IEnumerable<CategoryModel> LoadCategories()
        {
            return catRepo.GetAllElements();
        }

        
    }
}