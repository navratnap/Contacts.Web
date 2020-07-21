using System;
using System.Text;

namespace Contacts.Web.Common
{
    /// <summary>
    /// Encryption class to encrypt and decrypt the string
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// Encrypts the string to Base 64.
        /// </summary>
        /// <param name="ToEncrypt"></param>
        /// <returns>string</returns>
        public static string Encrypt(string ToEncrypt)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(ToEncrypt));
        }

        /// <summary>
        /// Decrypts the string from Base 64.
        /// </summary>
        /// <param name="cypherString"></param>
        /// <returns>string</returns>
        public static string Decrypt(string cypherString)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(cypherString));
        }
    }
}
