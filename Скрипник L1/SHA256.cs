using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Lab1
{
    public static class SHA256Calculator
    {
        public static string CalculateHash(this string word)
        {
            var algorithm = SHA256.Create();

            var sb = new StringBuilder();
            foreach(var b in algorithm.ComputeHash(Encoding.UTF8.GetBytes(word)))
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
