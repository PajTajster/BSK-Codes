using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    class VigenereCipher : ICipher
    {
        private const int letters = 26;
        private string key;

        public VigenereCipher(string k)
        {
            key = k.ToUpper();
        }

        public string Encrypt(string text)
        {
            text = text.ToUpper();

            StringBuilder encryptedText = new StringBuilder(text);
            

            int keyLetterPos = 0;
            for (int i = 0; i < text.Length; ++i)
            {
                if (Char.IsLetter(text[i]))
                {
                    encryptedText[i] = (char)(this.Modulo((text[i] + key[keyLetterPos]), letters) + 'A');
                }
                keyLetterPos = (keyLetterPos + 1) % key.Length;
            }

            return encryptedText.ToString();
        }
        public string Decrypt(string text)
        {
            text = text.ToUpper();
            StringBuilder decryptedText = new StringBuilder(text);
            
            int keyLetterPos = 0;
            for(int i = 0; i < text.Length; ++i)
            {
                if(Char.IsLetter(text[i]))
                {
                    decryptedText[i] = (char)(this.Modulo((text[i] - key[keyLetterPos]), letters) + 'A');
                }
                keyLetterPos = (keyLetterPos + 1) % key.Length;
            }

            return decryptedText.ToString();
        }
    }
}
