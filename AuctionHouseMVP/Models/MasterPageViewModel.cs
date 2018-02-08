using System;
using System.Collections.Generic;
using AHWForm.Models;
using AHWForm.Repos;
using Repositories;

namespace AHWForm.Presenter
{
    public class MasterPageViewModel : IMasterPageModel
    {
        public MasterPageViewModel()
        {
            catRepo = RepositoryFactory.GetRepositoryInstance<CategoryModel, CategoryRepository>();
        }

        private CategoryRepository catRepo { get; }

        public IEnumerable<CategoryModel> LoadCategories()
        {
            return catRepo.GetAllElements();
        }

        ~MasterPageViewModel()
        {
            catRepo.Dispose();
        }
    }
}