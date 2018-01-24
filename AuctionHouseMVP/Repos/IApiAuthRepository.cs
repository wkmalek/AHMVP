using AHWForm.Models;

namespace AHWForm.Repos
{
    public interface IApiAuthRepository
    {
        ApiUser GetApiUserByPublicKey(string ID);
        ApiUser GetApiUserByPrivateKey(string ID);
        ApiUser GetApiUserByUserID(string ID);
        ApiUser GetSingleApiUserById(string ID);
        void InsertUser(ApiUser model);
        void UpdateApiUser(ApiUser model);
        void Save();
    }
}