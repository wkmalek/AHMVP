using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AHWForm.ExtMethods
{
    public class EncryptionModule
    {
        private bool VerifyTokenDetails(string idToken, string exponent, string modulus)
        {
            try
            {
                var parts = idToken.Split('.');
                var header = parts[0];
                var payload = parts[1];
                string signedSignature = parts[2];
                //Extract user info from payload   
                string userInfo = Encoding.UTF8.GetString(Base64UrlDecode(payload));
                string originalMessage = string.Concat(header, ".", payload);
                byte[] keyBytes = Base64UrlDecode(modulus);
                string keyBase = Convert.ToBase64String(keyBytes);
                string key = @"<RSAKeyValue> <Modulus>" + keyBase + "</Modulus> <Exponent>" + exponent +
                             "</Exponent> </RSAKeyValue>";
                bool result = VerifyData(originalMessage, signedSignature, key);
                if (result)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }
            return false;
        }
        /// <summary>  
        /// Verifies encrypted signed message with public key encrypted original message.  
        /// </summary>  
        /// <param name="originalMessage">Original message as string. (Encrypted form)</param>  
        /// <param name="signedMessage">Signed message as string. (Encrypted form)</param>  
        /// <param name="publicKey">Public key as XML string.</param>  
        /// <returns>Boolean True if successful otherwise return false.</returns>  
        private static bool VerifyData(string originalMessage, string signedMessage, string publicKey)
        {
            bool success = false;
            using (var rsa = new RSACryptoServiceProvider())
            {
                var encoder = new UTF8Encoding();
                byte[] bytesToVerify = encoder.GetBytes(originalMessage);
                byte[] signedBytes = Base64UrlDecode(signedMessage);
                try
                {
                    rsa.FromXmlString(publicKey);
                    SHA256Managed Hash = new SHA256Managed();
                    byte[] hashedData = Hash.ComputeHash(signedBytes);
                    success = rsa.VerifyData(bytesToVerify, CryptoConfig.MapNameToOID("SHA256"), signedBytes);
                }
                catch (CryptographicException ex)
                {
                    Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                    success = false;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
            return success;
        }


        /// <summary>  
        /// Modify encrypted text to Base64 pattern and convert to bytes.  
        /// </summary>  
        /// <param name="input">Encrypted data as string.</param>  
        /// <returns>Base64 string as byte array.</returns>  
        private static byte[] Base64UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding  
            output = output.Replace('_', '/'); // 63rd char of encoding  
            switch (output.Length % 4) // Pad with trailing '='s  
            {
                case 0: break; // No pad chars in this case  
                case 2: output += "=="; break; // Two pad chars  
                case 3: output += "="; break; // One pad char  
                default: throw new System.Exception("Illegal base64url string!");
            }
            var converted = Convert.FromBase64String(output); // Standard base64 decoder  
            return converted;
        }
    }
}