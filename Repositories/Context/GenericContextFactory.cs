using System;
using System.CodeDom;
using System.Data.Entity;
using AHWForm.Models;

namespace Repositories.Context
{
    public class GenericContextFactory<T>: DbContext where T:class
    {
        public GenericContextFactory(string connection) : base("name=" + connection) { }
        public DbSet<T> dbSet { get; set; }
    }
}