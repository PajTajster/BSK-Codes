using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    class VigenerCipher
    {
        // encode: (K + W) mod n
        // encode: (C - R) mod n

        string key;

        public VigenerCipher(string k)
        {
            key = k;
        }

        string Encode(string text)
        {
            return "";
        }
        string Decode(string text)
        {
            return "";
        }
    }
}
