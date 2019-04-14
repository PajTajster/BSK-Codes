using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BSK03.DES
{
    class KeyGenerator
    {
        private BitArray[] cKeyPart = new BitArray[28];
        private BitArray[] dKeyPart = new BitArray[28];

        public BitArray[,] generatedKeys = new BitArray[16, 48];


        public void GenerateKeys(BitArray[] key)
        {
            for (int i = 0; i < 28; ++i)
            {

            }
        } 
    }
}
