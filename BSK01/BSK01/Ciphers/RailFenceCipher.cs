using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    class RailFenceCipher
    {
        private int key;

        public RailFenceCipher(int k)
        {
            key = k;
        }

        public string Encode(String text)
        {
            char[,] tab = new char[text.Length, key];

            for (int i = 0; i < text.Length; ++i)
            {
                for (int j = 0; j < key; ++j)
                {
                    tab[i, j] = ' ';
                }
            }

            bool isGoingDown = true;
            int row = 0;
            for (int i = 0; i < text.Length; ++i)
            {
                tab[i, row] = text[i];


                if (isGoingDown)
                {
                    ++row;
                    if (row == key - 1)
                        isGoingDown = false;
                }
                else
                {
                    --row;
                    if (row == 0)
                        isGoingDown = true;
                }
            }

            string newtext = "";
            for (int j = 0; j < key; ++j)
            {
                for (int i = 0; i < text.Length; ++i)
                {
                    if (tab[i, j] != ' ')
                    {
                        newtext += tab[i, j];
                    }
                }
            }

            return newtext;
        }

        public string Decode(string text)
        {
            char[,] tab = new char[text.Length, key];


            bool isGoingDown = true;
            int row = 0;


            for (int i = 0; i < text.Length; ++i)
            {
                tab[i, row] = '\t';


                if (isGoingDown)
                {
                    ++row;
                    if (row == key - 1)
                        isGoingDown = false;
                }
                else
                {
                    --row;
                    if (row == 0)
                        isGoingDown = true;
                }
            }


            isGoingDown = true;
            row = 0;

            string decodedText = "";
            int currentRowFilled = 0;
            int currentLetterAdded = 0;
            for (int _ = 0; _ < key; ++_)
            {
                isGoingDown = true;
                row = 0;
                for (int i = 0; i < text.Length; ++i)
                {
                    if (tab[i, row] == '\t' && row == currentRowFilled)
                    {
                        tab[i, row] = text[currentLetterAdded];
                        ++currentLetterAdded;
                    }


                    if (isGoingDown)
                    {
                        ++row;
                        if (row == key - 1)
                            isGoingDown = false;
                    }
                    else
                    {
                        --row;
                        if (row == 0)
                            isGoingDown = true;
                    }
                }
                ++currentRowFilled;
            }

            for (int i = 0; i < text.Length; ++i)
            {
                for (int j = 0; j < key; ++j)
                {
                    if (tab[i, j] != '\0')
                    {
                        decodedText += tab[i, j];
                    }
                }
            }

            return decodedText;
        }

    }

}
