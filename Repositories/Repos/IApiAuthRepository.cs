using AHWForm.Models;

namespace AHWForm.Repos
{
    public interface IApiAuthRepository<T>:IRepository<T> where T:class
    {
        T GetApiUserByPublicKey(string ID);
        T GetApiUserByPrivateKey(string ID);
        T GetApiUserByUserID(string ID);
    }
}