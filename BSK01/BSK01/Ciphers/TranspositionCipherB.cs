using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    class TranspositionCipherB : ICipher
    {

        private string key;

        private const int letters = 26;

        private int[] keyOrder;

        public TranspositionCipherB(string k)
        {
            key = k.ToUpper();

            keyOrder = new int[key.Length];
            char c;
            int order = 0;
            for (int i = 0; i < letters; ++i)
            {
                for (int j = 0; j < key.Length; ++j)
                {
                    c = (char)(i + 'A');
                    if(key[j] == c)
                    {
                        keyOrder[j] = order;
                        ++order;
                    }
                }
            }
        }
        
        public string Encrypt(string text)
        {
            string encryptedText = "";

            text = text.ToUpper();

            int col = key.Length;
            int row = text.Length / col;
            if(text.Length / col != 0)
            {
                ++row;
            }

            string[] tab = new string[key.Length];

            int currentLetter = 0;
            char c = ' ';
            for (int i = 0; i < key.Length; ++i)
            {
                if (currentLetter == text.Length)
                    break;

                if(text[currentLetter] == c)
                {
                    if (currentLetter == text.Length)
                        break;

                    --i;
                    ++currentLetter;
                    continue;
                }

                tab[i] += text[currentLetter];
                if (currentLetter == text.Length)
                    break;

                if (i + 1 == key.Length)
                    i = -1;

                ++currentLetter;
            }

            int order = 0;
            for (int i = 0; i < tab.Length; ++i)
            {
                for (int j = 0; j < tab.Length; ++j)
                {
                    if(keyOrder[j] == order)
                    {
                        encryptedText += tab[j];
                        ++order;
                        break;
                    }
                }
            }

            return encryptedText;
        }
        public string Decrypt(string text)
        {
            string decryptedText = "";

            string[] tab = new string[key.Length];

            int col = key.Length;
            int row = text.Length / col;
            bool isThereExtraRow = false;

            if (text.Length / col != 0)
            {
                ++row;
                isThereExtraRow = true;
            }

            int order = 0;
            if (isThereExtraRow)
            {
                int length = text.Length % key.Length;
                for (int i = 0; i < row - 1; ++i) 
                {
                    for (int j = 0; j < tab.Length; ++j)
                    {
                        tab[j] += "-";
                    }
                }
                for (int i = 0; i < length; ++i)
                {
                    tab[i] += "-";
                }

                for (int i = 0; i < text.Length; i += row - 1) 
                {
                    for (int j = 0; j < tab.Length; ++j) 
                    {
                        if(keyOrder[j] == order)
                        {
                            tab[j] = text.Substring(i, tab[j].Length);
                            if(tab[j].Length == row)
                            {
                                ++i;
                            }
                            ++order;
                            break;
                        }
                    }
                }

                for (int i = 0; i < row; ++i)
                {
                    for (int j = 0; j < tab.Length; ++j)
                    {
                        if( i != tab[j].Length)
                        {
                            decryptedText += tab[j].Substring(i, 1);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < row; ++i) 
                {
                    for(int j = 0; j < tab.Length; ++j)
                    {
                        tab[j] += "-";
                    }
                }

                for (int i = 0; i < key.Length; i += row) 
                {
                    for (int j = 0; j < tab.Length; ++j)
                    {
                        if(keyOrder[j] == order)
                        {
                            tab[j] = text.Substring(i, tab[j].Length);
                            ++order;
                            break;
                        }
                    }
                }

                for (int i = 0; i < row; ++i)
                {
                    for (int j = 0; j < tab.Length; ++j)
                    {
                        if(i != tab[j].Length)
                        {
                            decryptedText += tab[j].Substring(i, 1);
                        }
                    }
                }

            }


            return decryptedText;
        }

    }
}
