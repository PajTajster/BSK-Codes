using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BSK03.DES
{
    class KeyGenerator
    {
        private bool[] cKeyPart = new bool[28];
        private bool[] dKeyPart = new bool[28];

        public bool[] generatedKeys = new bool[16 * 48];

        public KeyGenerator(bool[] key)
        {
            GenerateKeys(key);
        }

        private void GenerateKeys(bool[] key)
        {
            for (int i = 0; i < 28; ++i)
            {
                cKeyPart[i] = key[Permutations.permutedChoice1[i] - 1];
                dKeyPart[i] = key[Permutations.permutedChoice2[i + 28] - 1];
            }


            bool[] connectedPartsKey = new bool[56];
            for (int i = 0; i < 16; ++i)
            {
                for (int j = 0; j < Permutations.leftShiftsIterationTable[i]; ++j)
                {
                    cKeyPart = LeftShift(cKeyPart);
                    dKeyPart = LeftShift(dKeyPart);
                }

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

        private bool[] LeftShift(bool[] original)
        {
            bool tmp = original[0];
            for (int i = 0; i < 27; ++i)
            {
                original[i] = original[i + 1];
            }
            original[27] = tmp;

            return original;
        }
    }
}
