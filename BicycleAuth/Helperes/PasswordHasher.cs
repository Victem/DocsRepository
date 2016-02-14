using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BicycleAuth
{
    public static class PasswordHasher
    {
        public static string HashPassword(string inputString)
        {
            byte[] stringBytes = ASCIIEncoding.ASCII.GetBytes(inputString);
            
            byte[] hashedStringBytes = new MD5CryptoServiceProvider().ComputeHash(stringBytes);

            return HasedBytesAsString(hashedStringBytes);
        }

        private static string HasedBytesAsString(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder(bytes.Length);
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("X2"));
            }
            return builder.ToString();
        }

        public static bool ComparePasswords(string unhasedPassword, string hashedPassword)
        {
            return HashPassword(unhasedPassword).Equals(hashedPassword);
        }
    }
}
