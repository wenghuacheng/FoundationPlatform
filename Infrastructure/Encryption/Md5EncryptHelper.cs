using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Encryption
{
    /// <summary>
    /// MD5加密长度为128位16进制字符串长度为32
    /// </summary>
    public class Md5EncryptHelper
    {
        /// <summary>
        /// 对字符串md5加密
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="encoding">编码类型</param>
        /// <returns>加密后的十六进制字符串</returns>
        public static string Md5Encrypt(string source, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;

            byte[] byteArray = encoding.GetBytes(source);
            using (HashAlgorithm hashAlgorithm = new MD5CryptoServiceProvider())
            {
                byteArray = hashAlgorithm.ComputeHash(byteArray);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte item in byteArray)
                {
                    stringBuilder.AppendFormat("{0:x2}", item);
                }
                hashAlgorithm.Clear();
                return stringBuilder.ToString();
            }
        }
    }
}
