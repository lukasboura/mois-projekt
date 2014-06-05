using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ProjektMOIS.Utils
{
    public class SHA1
    {
        public static string GetSHA1(string text)
        {
            System.Security.Cryptography.SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] ipBytes = Encoding.Default.GetBytes(text.ToCharArray());
            byte[] opBytes = sha1.ComputeHash(ipBytes);

            StringBuilder stringBuilder = new StringBuilder(40);
            for (int i = 0; i < opBytes.Length; i++)
            {
                stringBuilder.Append(opBytes[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}