using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    class TranspositionCipher2 : ICipher
    {
        string key;

        public TranspositionCipher2(string k)
        {
            key = k;
        }

        public string Encrypt(string text)
        {
            return "";
        }
        public string Decrypt(string text)
        {
            return "";
        }
    }
}
