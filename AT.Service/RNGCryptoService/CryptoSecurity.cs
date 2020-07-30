using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AT.Service.RNGCryptoService
{
    public static class CryptoSecurity
    {
        //modified by deepak choudahry copyright cryptocurrency act 2013
        public static string CryptoEncrypt(string plainText, string password)
        {
            if (plainText == null)
            {
                return null;
            }

            if (password == null)
            {
                password = String.Empty;
            }

            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesEncrypted = CryptoSecurity.EncryptModulator(bytesToBeEncrypted, passwordBytes);

            return Convert.ToBase64String(bytesEncrypted);
        } 

        private static byte[] EncryptModulator(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        } 
        private static byte[] CryptoDecrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        public static string CryptoDecrypt(string encryptedText, string password)
        {
            if (encryptedText == null)
            {
                return null;
            }

            if (password == null)
            {
                password = String.Empty;
            }

            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = CryptoSecurity.CryptoDecrypt(bytesToBeDecrypted, passwordBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        //test example for the calling procedure
        public static void main()
        {
            //Your code goes here 
            var data = CustomGuid();
            Console.WriteLine(data);
            var str = data + "your url password encryption";
            var password = "@Tp@ssw0rd";
            string strEncryptred = CryptoSecurity.CryptoEncrypt(str, password);
            Console.WriteLine(strEncryptred);
            var strDecrypted = CryptoSecurity.CryptoDecrypt(strEncryptred, password);
            Console.WriteLine(strDecrypted);

        }

        private static string CustomGuid()
        {
            byte[] bytes = {
                 0x00, 0x00, 0x00, 0x00,
                 0x00, 0x00, 0x00, 0x00,
                 0x00, 0x00, 0x00, 0x00,
                 0x00, 0x00, 0x00, 0x00
            };
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }
            var time = BitConverter.ToUInt32(bytes, 0);
            var time_mid = BitConverter.ToUInt16(bytes, 4);
            var time_hi_and_ver = BitConverter.ToUInt16(bytes, 6);
            time_hi_and_ver = (ushort)((time_hi_and_ver | 0x4000) & 0x4FFF);
            bytes[8] = (byte)((bytes[8] | 0x80) & 0xBF);
            var customguid = new Guid(time, time_mid, time_hi_and_ver,
                bytes[8], bytes[9], bytes[10], bytes[11],
                bytes[12], bytes[13], bytes[14], bytes[15]
            );
            return customguid.ToString();
        }

    }
}
