using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AHWForm.Repos;
using Repositories.Context;

namespace Repositories
{
    public abstract class AbstractRepostiory<T> : IRepository<T>, IDisposable where T : class
    {
        private bool disposed;
        protected GenericContextFactory<T> context { get; set; }

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

        ~AbstractRepostiory()
        {
            Dispose(false);
        }

    }
}