using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AHWForm.Models;
using Repositories;
using Repositories.Context;

namespace AHWForm.Repos
{
    public class ApiAuthRepository:AbstractRepostiory<ApiUser>,IApiAuthRepository<ApiUser>
    {
        public ApiAuthRepository()
        {
            context = new GenericContextFactory<ApiUser>("ApiUsersContext");
        }

        public ApiUser GetApiUserByPublicKey(string ID)
        {
            return context.dbSet.SingleOrDefault(x => x.PublicKey == ID);
        }

        public ApiUser GetApiUserByPrivateKey(string ID)
        {
            return context.dbSet.SingleOrDefault(x => x.PrivateKey == ID);
        }

        public ApiUser GetApiUserByUserID(string ID)
        {
            return context.dbSet.SingleOrDefault(x => x.UserId == ID);
        }
  
    }
}