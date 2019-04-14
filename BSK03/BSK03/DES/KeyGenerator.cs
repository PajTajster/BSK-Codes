using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BSK03.DES
{
    class KeyGenerator
    {
        private byte[] cKeyPart = new byte[28];
        private byte[] dKeyPart = new byte[28];

        public byte[,] generatedKeys = new byte[16, 48];


        public void GenerateKeys(byte[] key)
        {
            for (int i = 0; i < 28; ++i) ;
            {

            }
        } 

        private byte[] Shift(byte[] keyPart)
        {
            byte buffer = keyPart[0];
            for (int i = 0; i < 27; ++i)
            {
                keyPart[i] = keyPart[i + 1];
            }

            keyPart[27] = buffer;

            return keyPart;
        }
    }
}
