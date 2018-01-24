using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AHWForm.Models;

namespace AHWForm.Repos
{
    public class ApiAuthRepository:IApiAuthRepository, IDisposable
    {
        public class ApiUsersContext : DbContext
        {
            public ApiUsersContext() : base("name=ApiUsersContext")
            {

            }
            public DbSet<ApiUser> ApiUsers { get; set; }

        }
        private ApiUsersContext context { get; set; }

        public ApiAuthRepository()
        {
            context = new ApiUsersContext();
        }

        public ApiUser GetApiUserByPublicKey(string ID)
        {
            return context.ApiUsers.SingleOrDefault(x => x.PublicKey == ID);
        }

        public ApiUser GetApiUserByPrivateKey(string ID)
        {
            return context.ApiUsers.SingleOrDefault(x => x.PrivateKey == ID);
        }

        public ApiUser GetApiUserByUserID(string ID)
        {
            return context.ApiUsers.SingleOrDefault(x => x.UserId == ID);
        }

        public ApiUser GetSingleApiUserById(string ID)
        {
            return context.ApiUsers.Find(ID);
        }

        public void InsertUser(ApiUser model)
        {
            context.ApiUsers.Add(model);
        }

        public void UpdateApiUser(ApiUser model)
        {
            context.Entry(model).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
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