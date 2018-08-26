using System;
using System.Security.Cryptography;
using System.Text;

namespace DeviceManager.Common
{
    public class PasswordHelper
    {

        // Create password MD5
        public static string EncodePasswordMd5(string pass)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }

        // Verify password
        public static bool VerifyPassword(string pass1, string pass2)
        {
            if (pass1.Equals(pass2))
                return true;
            else
                return false;
        }

    }
}
