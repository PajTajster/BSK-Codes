using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    class VigenereCipher : ICipher
    {
        // encode: (K + W) mod n
        // encode: (C - R) mod n

        private string key;
        private readonly int letters = 26;

        public VigenereCipher(string k)
        {
            key = k;
        }

        public string Encrypt(string text)
        {
            string encodedtext = "";

            for(int i = 0; i < text.Length; ++i)
            {
                bool isUpper = char.IsUpper(text[i]);

                char offset = isUpper ? 'A' : 'a';

                int keyIndex = i % key.Length;
                int keyOffset = isUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex]);

                char encodedLetter = (char)(((text[i] + keyOffset) - offset) % letters + offset);
                encodedtext += encodedLetter;
            }

            return encodedtext;
        }
        public string Decrypt(string text)
        {
            string decodedText = "";

            for (int i = 0; i < text.Length; ++i)
            {
                bool isUpper = char.IsUpper(text[i]);

                char offset = isUpper ? 'A' : 'a';

                int keyIndex = i % key.Length;
                int keyOffset = isUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex]);

                char encodedLetter = (char)(((text[i] - keyOffset) - offset) % letters + offset);
                decodedText += encodedLetter;
            }

            return decodedText;
        }
    }
}
