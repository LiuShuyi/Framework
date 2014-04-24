using System.Security.Cryptography;
using System.Text;

namespace Framework.Helper
{
    public static class EncrypHelper
    {
        /// <summary>
        /// GetMD5
        /// </summary>
        /// <param name="s"></param>
        /// <param name="inputCharset"></param>
        /// <returns></returns>
        public static string GetMd5(string s, string inputCharset)
        {
            var buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding(inputCharset).GetBytes(s));
            var builder = new StringBuilder(0x20);
            for (var i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x").PadLeft(2, '0'));
            }
            return builder.ToString();
        }
    }
}
