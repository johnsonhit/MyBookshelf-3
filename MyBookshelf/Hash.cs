using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MyBookshelf
{
    class Hash
    {
        public static string PasswordSalt
        {
            get
            {
                var rng = new RNGCryptoServiceProvider();
                var buff = new byte[16];
                rng.GetBytes(buff);
                rng.Dispose();
                return Convert.ToBase64String(buff);
            }
        }

        public static string EncodePassword(string password, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create("SHA256");
            byte[] inarray = hashAlgorithm.ComputeHash(dst);
            hashAlgorithm.Dispose();
            return Convert.ToBase64String(inarray);
        }
    }
}
