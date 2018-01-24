using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using AHWForm.Models;
using AHWForm.Repos;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System.Security.Cryptography;
namespace AHWForm.ExtMethods
{
    public class ApiPostDecrypter
    {
        public ApiPostDecrypter(IApiAuthRepository repo)
        {
            this.Repo = repo;
        }

        private IApiAuthRepository Repo;
        public bool GetData<T>(ApiDataObject obj, out T output)
        {
            output = (T)obj.data;
            if (CheckAuth(obj)) 
                if (CheckDataFormat(obj))
                    return true;
                    return false;

    }

        private bool CheckDataFormat(ApiDataObject obj)
        {
            //TODO
            return true;
        }

        private bool CheckAuth(ApiDataObject obj)
        {
            //DpapiDataProtectionProvider encryptProvider = new DpapiDataProtectionProvider();
            ProtectedData encryptProvider = new 
            //TODO
            var apiUser = Repo.GetApiUserByPublicKey(obj.PublicKey);
            var unhashedUser = encryptProvider;
            var unhashedPass;            
            //HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().CheckPasswordAsync()
            return true;
        }
    }