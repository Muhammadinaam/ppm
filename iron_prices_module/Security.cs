/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 08/02/2014
 * Time: 12:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Management;
using System.Security.Cryptography;
using System.Security;
using System.Collections;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Module
{
    

    public static class StringCipher
    {
        
        public static string Encrypt(string text, string key)
        {


            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 256;
            aes.Padding = PaddingMode.Zeros;
            aes.Mode = CipherMode.CBC;

            PasswordDeriveBytes password = new PasswordDeriveBytes(key, null);
            aes.Key = password.GetBytes(aes.KeySize / 8);

            aes.GenerateIV();

            string IV = ("-[--IV-[-" + Encoding.Default.GetString(aes.IV));

            ICryptoTransform AESEncrypt = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] buffer = Encoding.Default.GetBytes(text);

            return Convert.ToBase64String(Encoding.Default.GetBytes(Encoding.Default.GetString(AESEncrypt.TransformFinalBlock(buffer, 0, buffer.Length)) + IV));

        }

        public static string Decrypt(string text, string key)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 256;
            aes.Padding = PaddingMode.Zeros;
            aes.Mode = CipherMode.CBC;


            PasswordDeriveBytes password = new PasswordDeriveBytes(key, null);
            aes.Key = password.GetBytes(aes.KeySize / 8);

            text = Encoding.Default.GetString(Convert.FromBase64String(text));

            string IV = text;
            IV = IV.Substring(IV.IndexOf("-[--IV-[-") + 9);
            text = text.Replace("-[--IV-[-" + IV, "");

            text = Convert.ToBase64String(Encoding.Default.GetBytes(text));
            aes.IV = Encoding.Default.GetBytes(IV);

            ICryptoTransform AESDecrypt = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] buffer = Convert.FromBase64String(text);

            return Encoding.Default.GetString(AESDecrypt.TransformFinalBlock(buffer, 0, buffer.Length));
        }
    }
}
