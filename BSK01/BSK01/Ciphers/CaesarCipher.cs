using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    class CaesarCipher : ICipher
    {
        private readonly int letters = 72;
        private readonly int eulerTotient = 24;

        private int key1Power;


        private int key0;
        private int key1;
        public CaesarCipher(int k0, int k1)
        {
            key0 = k0;
            key1 = k1;

            key1Power = Convert.ToInt32((Math.Ceiling(Math.Pow(key1, eulerTotient - 1))));
        }

        // c = (a * k1 + k0) mod n

        public string Encrypt(string text)
        {
            string encodedText = "";

            for (int i = 0; i < text.Length; ++i) 
            {
                int value = (text[i] * key1) + key0;

                encodedText += mod(value, letters);
            }

            return encodedText;
        }

        // a = [c + (n - k0)] * key1power mod n

        public string Decrypt(string text)
        {
            string decodedText = "";

            for (int i = 0; i < text.Length; ++i)
            {
                int value = (text[i] * (letters - key0)) * key1Power;

                decodedText += mod(value, letters);
            }

            return decodedText;
        }
        int mod(int x, int m)
        {
            int r = x % m;
            return r < 0 ? r + m : r;
        }

    }
}
