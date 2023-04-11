using System;
using System.Security.Cryptography;
using System.Text;

namespace Smc.Application.Password
{
    public class AspMenberchipHashAlikeProvider : IPasswordEncriptionProvider
    {
        public string EncriptPassword(string password, string salt)
        {

            byte[] bIn = Encoding.Unicode.GetBytes(password);
            byte[] bSalt = Convert.FromBase64String(salt);
            byte[] bAll = new byte[bSalt.Length + bIn.Length];

            Buffer.BlockCopy(bSalt, 0, bAll, 0, bSalt.Length);
            Buffer.BlockCopy(bIn, 0, bAll, bSalt.Length, bIn.Length);

            // MembershipPasswordFormat.Hashed
            HashAlgorithm s = HashAlgorithm.Create("SHA1");
            // Hardcoded "SHA1" instead of Membership.HashAlgorithmType
            return Convert.ToBase64String(s.ComputeHash(bAll));
        }
    }
}
