using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HX.Rider.Common.Helper
{
    public class SecureHelper
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <param name="code">加密位数16/32</param>
        /// <returns></returns>
        public static string Encrypt(string str, int code)
        {
            string strEncrypt = string.Empty;
            if (code == 16)
                strEncrypt = MD5(str).Substring(8, 16);
            if (code == 32)
                strEncrypt = MD5(str);
            return strEncrypt;
        }
        /// <summary>
        /// 32位MD5加密（小写）
        /// </summary>
        /// <param name="input">输入字段</param>
        /// <returns></returns>
        public static string MD5(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("input", "SecureHelper.MD5");
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        /// <summary>
        /// MD5+盐加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string MD5AddingSalt(string input, string salt)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("input", "SecureHelper.MD5AddingSalt");
            if (string.IsNullOrEmpty(salt))
                throw new ArgumentNullException("salt", "SecureHelper.MD5AddingSalt");
            string md5Input = MD5(input);
            return MD5(md5Input + salt);
        }


        /// <summary>
		/// Base64加密
		/// </summary>
		/// <param name="source">待加密的明文</param>
		/// <returns></returns>
		public static string Base64Encode(string source)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            try
            {
                return  Convert.ToBase64String(bytes);
            }
            catch
            {
                return  source;
            }
        }
    }
}
