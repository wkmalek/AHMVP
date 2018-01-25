using AHWForm.Models;

namespace AHWForm.ExtMethods
{
    public class ApiPostDecrypter
    {
        public ApiPostDecrypter(IApiAuthRepository<ApiUser> repo)
        {
            this.Repo = repo;
        }

        private IApiAuthRepository<ApiUser> Repo;

        public bool GetData<T>(ApiDataObject obj, out T output)
        {
            output = (T) obj.data;
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
            
            return true;
        }
    }
}