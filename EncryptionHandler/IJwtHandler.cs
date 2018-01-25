using System.Diagnostics;
using EncryptionHandler;
using Microsoft.IdentityModel.Tokens;


namespace Encryption
{
    public interface IJwtHandler
    {
        JWT Create(string userID);
        TokenValidationParameters Parameters { get; }
    }
}