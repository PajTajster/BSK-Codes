using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    class VigenerCipher
    {
        // encode: (K + W) mod n
        // encode: (C - R) mod n

        private string key;
        private readonly int letters = 26;

        public VigenerCipher(string k)
        {
            key = k;
        }

        public string Encode(string text)
        {
            string encodedtext = "";

            for(int i = 0; i < text.Length; ++i)
            {
                bool isUpper = char.IsUpper(text[i]);

                char offset = isUpper ? 'A' : 'a';

                int keyIndex = i % key.Length;
                int keyOffset = isUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex]);

                char encodedLetter = (char)(((text[i] + keyOffset) - offset) % 26 + offset);
                encodedtext += encodedLetter;
            }

            return encodedtext;
        }
        public string Decode(string text)
        {
            string decodedText = "";

            for (int i = 0; i < text.Length; ++i)
            {
                bool isUpper = char.IsUpper(text[i]);

                char offset = isUpper ? 'A' : 'a';

                int keyIndex = i % key.Length;
                int keyOffset = isUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex]);

                char encodedLetter = (char)(((text[i] - keyOffset) - offset) % 26 + offset);
                decodedText += encodedLetter;
            }

            return decodedText;
        }
    }
}
