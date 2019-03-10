using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    class TranspositionCipherA : ICipher
    {
        private readonly int[] key = {3, 4, 1, 5, 2};

        public string Encrypt(string text)
        {
            string encryptedText = "";

            int rows = text.Length / key.Length;
            if(text.Length % key.Length != 0)
            {
                ++rows;
            }

            int currentCol = 0;
            string[] tab = new string[rows];
            for (int i = 0; i < text.Length; i += key.Length) 
            {
                if(key.Length + i < text.Length)
                {
                    tab[currentCol] += text.Substring(i, key.Length);
                }
                else
                {
                    tab[currentCol] += text.Substring(i);
                }
                ++currentCol;
            }

            for(int i = 0; i < rows; ++i)
            {
                for(int j = 0; j < key.Length; ++j)
                {
                    if (tab[i].Length < key[j])
                        continue;

                    encryptedText += tab[i].Substring(key[j] - 1, 1);
                }
            }

            return encryptedText;
        }
        public string Decrypt(string text)
        {
            string decryptedText = "";

            int rows = text.Length / key.Length;
            if(text.Length % key.Length != 0)
            {
                ++rows;
            }

            string[] tab = new string[text.Length];



            return decryptedText;
        }
    }
}
