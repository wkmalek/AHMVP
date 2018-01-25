using System.Collections.Generic;
using AHWForm.Models;

namespace AHWForm.Repos
{
    public interface IRepository<T> where T:class
    {
        T GetSingleElementByID(string ID);
        List<T> GetAllElements();
        void Insert(T model);
        void Update(T model);
        void Save();
    }
}