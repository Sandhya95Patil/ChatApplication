//-----------------------------------------------------------------------
// <copyright file="PasswordEncrypt.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace RepositoryLayer.EncryptPassword
{
    using System;
    using System.Text;

    /// <summary>
    /// PasswordEncrypt class
    /// </summary>
    public class PasswordEncrypt
    {
        /// <summary>
        /// Encrypt data method
        /// </summary>
        /// <param name="password">password parameter</param>
        /// <returns>returns encrypted password</returns>
        public static string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
    }
}
