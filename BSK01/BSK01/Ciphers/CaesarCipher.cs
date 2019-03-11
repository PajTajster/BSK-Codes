using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    class CaesarCipher : ICipher
    {
        // f(n) - 1
        private readonly int eulerTotient = 31;
        private readonly int letters = 78;

        private readonly int startingLetter = 48;

        private int key1Power;


        private int key0;
        private int key1;
        public CaesarCipher(int k0, int k1)
        {
            key0 = k0;
            key1 = k1;

            key1Power = key1;
            for (int i = 0; i < eulerTotient; ++i) 
            {
                key1Power = (key1Power * key1) % letters;
            }
        }

        // c = (a * k1 + k0) mod n

        public string Encrypt(string text)
        {
            string encryptedText = "";

            for (int i = 0; i < text.Length; ++i) 
            {
                int value = (text[i] * key1) + key0;

                encryptedText += (char)(this.Modulo(value, letters) + startingLetter);
            }

            return encryptedText;
        }

        // a = [c + (n - k0)] * key1power mod n

        public string Decrypt(string text)
        {
            string decryptedText = "";

            for (int i = 0; i < text.Length; ++i)
            {
                int value = (text[i] * (letters - key0)) * key1Power;

                decryptedText += (char)(this.Modulo(value, letters) + startingLetter);
            }

            return decryptedText;
        }

    }
}
