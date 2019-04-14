using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BSK03.DES
{
    class DES
    {
        public bool[] Encrypt(bool[] data, bool[] key)
        {
            throw new NotImplementedException();
        }
        public bool[] Decrypt(bool[] data, bool[] key)
        {
            throw new NotImplementedException();
        }

        private bool[] FeistelFunction(bool[] dataRightPart, bool[] key)
        {
            throw new NotImplementedException();
        }
        private bool[] InitialPermute(bool[] data)
        {
            bool[] result = new bool[64];

            for (int i = 0; i < 64; ++i)
            {
                result[i] = data[Permutations.initialPermutation[i] - 1];
            }

            return result;
        }
        private bool[] FinalPermute(bool[] data)
        {
            bool[] result = new bool[64];

            for (int i = 0; i < 64; ++i)
            {
                result[i] = data[Permutations.finalPermutation[i] - 1];
            }

            return result;
        }
    }
}
