using AHWForm.Models;
using AHWForm.Repos;


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