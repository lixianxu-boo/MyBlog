using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Code
{
    public class Md5Helper
    {
        public static string Md5Encrypt32(string pwd)
        {
            string password = string.Empty;
            MD5 md5 = MD5.Create();
            var s = md5.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            for (int i = 0; i < s.Length; i++)
            {
                password = password + s[i].ToString("X");
            }
            return password;
        }
    }
}
