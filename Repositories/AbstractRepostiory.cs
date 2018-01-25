using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHWForm.Models;
using AHWForm.Repos;
using Repositories.Context;

namespace Repositories
{
    public abstract class AbstractRepostiory<T>:IRepository<T>,IDisposable where T:class
    {
        protected GenericContextFactory<T> context { get; set; }
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

        public T GetSingleElementByID(string ID)
        {
            return context.dbSet.Find(ID);
        }

        public void Insert(T model)
        {
            context.dbSet.Add(model);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Update(T model)
        {
            context.Entry(model).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public List<T> GetAllElements()
        {
            return context.dbSet.ToList();
        }
    }
}
