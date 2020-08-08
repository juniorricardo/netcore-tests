using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BasicEssentials
{
    class GenerateHash
    {
        public static string GetSHA1()
        {
            using (SHA1 sha1 = SHA1Managed.Create())
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha1.ComputeHash(encoding.GetBytes(DateTime.Now.ToString("")));
                for (int i = 0; i < stream.Length; i++)
                    sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }
        }
    }
}
