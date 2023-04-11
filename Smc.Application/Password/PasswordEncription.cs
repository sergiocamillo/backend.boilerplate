using System;
using System.Security.Cryptography;

namespace Smc.Application.Password
{
    public static class PasswordEncription
    {
        private static IPasswordEncriptionProvider provider = new Password.AspMenberchipHashAlikeProvider();
        public static string GenerateSalt()
        {
            byte[] buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static IPasswordEncriptionProvider Provider { get { return provider; } set { provider = value; } }

        public static string EncriptPassword(string password, string salt)
        {
            return provider.EncriptPassword(password, salt);
        }
    }
}
