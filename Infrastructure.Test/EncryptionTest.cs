using System;
using Infrastructure.Encryption;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.Test
{
    [TestClass]
    public class EncryptionTest
    {
        [TestMethod]
        public void AesEncrypt_Encrypt()
        {
            var source = "abcefg";
            var ciphertext = AesEncryptHelper.EncryptAes(source);
            var text = AesEncryptHelper.DecryptAes(ciphertext);

            Assert.AreEqual<string>(source, text);
        }

        [TestMethod]
        public void DesEncrypt_Encrypt()
        {
            var source = "abcefg";
            var ciphertext = AesEncryptHelper.EncryptAes(source);
            var text = AesEncryptHelper.DecryptAes(ciphertext);

            Assert.AreEqual<string>(source, text);
        }

        [TestMethod]
        public void Md5Encrypt()
        {
            var source = "abcefg";
            var ciphertext = Md5EncryptHelper.Md5Encrypt(source);
            Assert.AreEqual<int>(ciphertext.Length, 32);
        }

        [TestMethod]
        public void Sha1EncryptEncrypt()
        {
            var source = "abcefg";
            var ciphertext = Sha1EncryptHelper.Sha1Encrypt(source);
            Assert.AreEqual<int>(ciphertext.Length, 40);
        }
    }
}
