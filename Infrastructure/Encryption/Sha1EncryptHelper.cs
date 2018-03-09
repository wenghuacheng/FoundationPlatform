using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Encryption
{
    /// <summary>
    /// 安全哈希算法
    /// 加密长度为160位16进制字符串长度为40
    /// 比MD5安全但速度慢
    /// </summary>
    public class Sha1EncryptHelper
    {
        /// <summary>
        /// 对字符串SHA1加密
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="encoding">编码类型</param>
        /// <returns>加密后的十六进制字符串</returns>
        public static string Sha1Encrypt(string source, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;

            byte[] byteArray = encoding.GetBytes(source);
            using (HashAlgorithm hashAlgorithm = new SHA1CryptoServiceProvider())
            {
                byteArray = hashAlgorithm.ComputeHash(byteArray);
                StringBuilder stringBuilder = new StringBuilder(256);
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
