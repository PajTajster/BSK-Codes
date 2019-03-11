using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    class CaesarCipher : ICipher
    {
        private readonly int letters = 26;

        private readonly int startingLetter = 65;


        private int key0;
        private int key1;
        public CaesarCipher(int k0, int k1)
        {
            key0 = k0;
            key1 = k1;
        }

        private int MulInverse(int a)
        {
            int result = 1;
            for (int i = 1; i < letters + 1; ++i)
            {
                if ((a * i) % letters == 1)
                {
                    result = i;
                    return result;
                }
            }
            return result;
        }

        public string Encrypt(string text)
        {
            string encryptedText = "";

            char[] textArray = text.ToUpper().ToCharArray();

            foreach (var item in textArray)
            {
                int x = Convert.ToInt32(item - startingLetter);
                encryptedText += Convert.ToChar(((key1 * x + key0) % letters) + startingLetter);
            }

            return encryptedText;
        }

        public string Decrypt(string text)
        {
            string decryptedText = "";

            int key1Inverse = MulInverse(key1);

            char[] charArray = text.ToUpper().ToCharArray();

            foreach (var item in charArray)
            {
                int x = Convert.ToInt32(item - startingLetter);
                if (x - key0 < 0) 
                {
                    x = Convert.ToInt32(x) + letters; 
                }

                decryptedText += Convert.ToChar(((key1Inverse * (x - key0)) % letters) + startingLetter);
            }

            return decryptedText;
        }

    }
}
