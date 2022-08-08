using System;
using System.Security.Cryptography;
using System.Text;

namespace Models
{
    internal static class PasswordHash
    {
        static SHA256 sha256 = SHA256.Create();

        public static string ComputeHash(string password)
        {
            return Convert.ToBase64String(
                sha256.ComputeHash(Encoding.Default.GetBytes(password)));
        }
    }
}
