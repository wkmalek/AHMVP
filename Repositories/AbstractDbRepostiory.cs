using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Xml;
using AHWForm.Repos;
using Repositories.Context;

namespace Repositories
{
    public abstract class AbstractDbRepostiory<T> : IRepository<T>, IDisposable where T : class
    {
        private bool disposed;
        protected GenericContextFactory<T> context { get; set; }

        protected virtual void Connect()
        {
            context = new GenericContextFactory<T>(ContextHelper.GetConnectionString(typeof(T)));
        }

        public T GetSingleElementByID(string ID)
        {
            Connect();
            var output = context.dbSet.Find(ID);
            context.Dispose();
            return output;
        }

        public void Insert(T model)
        {
            Connect();
            context.dbSet.Add(model);
            context.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Update(T model)
        {
            Connect();
            context.Entry(model).State = EntityState.Modified;
            context.Dispose();
        }

        public void Save()
        {
            Connect();
            context.SaveChanges();
            context.Dispose();
        }

        public List<T> GetAllElements()
        {
            Connect();
            var output = context.dbSet.ToList();
            context.Dispose();
            return output;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && context != null)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }

        ~AbstractDbRepostiory()
        {
            Dispose(false);
        }

    }
}