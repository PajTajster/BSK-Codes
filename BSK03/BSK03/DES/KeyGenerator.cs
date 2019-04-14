using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BSK03.DES
{
    class KeyGenerator
    {
        private BitArray cKeyPart = new BitArray(28);
        private BitArray dKeyPart = new BitArray(28);

        public BitArray generatedKeys = new BitArray(16 * 48);

        public KeyGenerator(BitArray key)
        {
            GenerateKeys(key);
        }

        private void GenerateKeys(BitArray key)
        {
            for (int i = 0; i < 28; ++i)
            {
                cKeyPart[i] = key[Permutations.permutedChoice1[i] - 1];
                dKeyPart[i] = key[Permutations.permutedChoice2[i + 28] - 1];
            }


            BitArray connectedPartsKey = new BitArray(56);
            for (int i = 0; i < 16; ++i)
            {
                cKeyPart.LeftShift(Permutations.leftShiftsIterationTable[i]);
                dKeyPart.LeftShift(Permutations.leftShiftsIterationTable[i]);

                for (int j = 0; j < 28; ++j)
                {
                    connectedPartsKey[j] = cKeyPart[j];
                    connectedPartsKey[j + 28] = dKeyPart[j];
                }

                for (int j = 0; j < 48; ++j)
                {
                    generatedKeys[(i * 16) + j] = connectedPartsKey[Permutations.permutedChoice2[j] - 1];
                }
            }
        } 
    }
}
