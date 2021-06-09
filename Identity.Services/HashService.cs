using System;
using System.Security.Cryptography;
using System.Text;

namespace Identity.Service
{
    public class HashService : IHashService
    {
        private readonly string _key;
        public HashService(string key)
        {
            _key = key;
        }

        public string Hash(string data)
        {
            return Convert.ToBase64String(HashHMAC(_key, data));
        }

        private byte[] HashHMAC(string key, string message)
        {
            var keyArray = StringEncode(key);
            var messageArray = StringEncode(message);
            var hash = new HMACSHA256(keyArray);
            return hash.ComputeHash(messageArray);
        }

        private byte[] StringEncode(string text)
        {
            var encoding = new ASCIIEncoding();
            return encoding.GetBytes(text);
        }
    }
}
