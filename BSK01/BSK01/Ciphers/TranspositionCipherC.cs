using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    class TranspositionCipherC : ICipher
    {
        string key;

        public TranspositionCipherC(string k)
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
