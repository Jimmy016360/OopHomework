using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using MyBackupCandidate;

namespace MyBackup
{
    /// <summary>
    /// Encode handler.
    /// </summary>
    public class EncodeHandler : AbstractHandler
    {
        private static readonly string encodePass = "mybackupservicepassword";
        private static readonly string encodeSalt = "神腦國際股份有限公司";

        /// <summary>
        /// Perform the specified candidate and target.
        /// </summary>
        /// <returns>The perform.</returns>
        /// <param name="candidate">Candidate.</param>
        /// <param name="target">Target.</param>
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            byte[] result = target;
            base.Perform(candidate, target);
            if (target != null)
            {
                result = this.EncodeData(candidate, target);
            }
            return result;
        }

        /// <summary>
        /// Encodes the data.
        /// </summary>
        /// <returns>The data.</returns>
        /// <param name="candidate">Candidate.</param>
        /// <param name="target">Target.</param>
        private byte[] EncodeData(Candidate candidate, byte[] target)
        {
            return AESEncryptBytes(target, Encoding.UTF8.GetBytes(encodePass), Encoding.UTF8.GetBytes(encodeSalt));
        }

        /// <summary>
        /// AES 加密
        /// </summary>
        /// <param name="clearBytes">加密前資料</param>
        /// <param name="passBytes">密文</param>
        /// <param name="saltBytes">鹽</param>
        /// <returns>加密後資料</returns>
        public byte[] AESEncryptBytes(byte[] clearBytes, byte[] passBytes, byte[] saltBytes)
        {
            byte[] encryptedBytes = null;

            // create a key from the password and salt, use 32K iterations – see note
            var key = new Rfc2898DeriveBytes(passBytes, saltBytes, 32768);

            // create an AES object
            using (Aes aes = new AesManaged())
            {
                // set the key size to 256
                aes.KeySize = 256;
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }

        /// <summary>
        /// AES 解密
        /// </summary>
        /// <param name="cryptBytes">加密資料</param>
        /// <param name="passBytes">密文</param>
        /// <param name="saltBytes">鹽</param>
        /// <returns></returns>
        public byte[] AESDecryptBytes(byte[] cryptBytes, byte[] passBytes, byte[] saltBytes)
        {
            byte[] clearBytes = null;

            // create a key from the password and salt, use 32K iterations
            var key = new Rfc2898DeriveBytes(passBytes, saltBytes, 32768);

            using (Aes aes = new AesManaged())
            {
                // set the key size to 256
                aes.KeySize = 256;
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cryptBytes, 0, cryptBytes.Length);
                        cs.Close();
                    }
                    clearBytes = ms.ToArray();
                }
            }
            return clearBytes;
        }
    }
}
