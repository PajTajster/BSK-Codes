using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    class TranspositionCipherC : ICipher
    {
        private string key;
        List<KeyValuePair<char, int>> keyOrder;

        public TranspositionCipherC(string k)
        {
            key = k.ToUpper();


            keyOrder = new List<KeyValuePair<char, int>>();
            for (int i = 0; i < key.Length; ++i)
            {
                keyOrder.Add(new KeyValuePair<char, int>(key[i], i + 1));
            }

            keyOrder.Sort((k1, k2) => k1.Key.CompareTo(k2.Key));

        }

        public string Encrypt(string text)
        {
            string encryptedText = "";

            text = text.ToUpper();

            for(int i = 0; i < keyOrder.Count; ++i)
            {
                int letterIndex = keyOrder[i].Value - 1;

                for (int j = 0; j < keyOrder.Count; ++j)
                {
                    if ((keyOrder[i].Value <= keyOrder[j].Value) && (letterIndex < text.Length)) 
                    {
                        encryptedText += text[letterIndex];
                    }

                    letterIndex += keyOrder[j].Value;
                }
            }

            return encryptedText;
        }
        public string Decrypt(string text)
        {
            StringBuilder decryptedText = new StringBuilder(text);

            int rows = 0, k = 0;

            for (int i = 0; i < keyOrder.Count; ++i)
            {
                k += keyOrder[i].Value;
                ++rows;
                if (k >= text.Length)
                    break;
            }

            int textPos = 0;
            for (int i = 0; i < keyOrder.Count; ++i)
            {
                int letterIndex = keyOrder[i].Value - 1;
                int currentRow = 0;
                for (int j = 0; j < keyOrder.Count; ++j)
                {
                    if(currentRow >= rows || letterIndex >= text.Length)
                        break;

                    if(keyOrder[i].Value <= keyOrder[j].Value)
                    {
                        decryptedText[letterIndex] = text[textPos];
                        ++textPos;
                    }
                    letterIndex += keyOrder[j].Value;
                    ++currentRow;
                }
            }

            return decryptedText.ToString();
        }
    }
}
