using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BSK03.DES
{
    class DES
    {
        public BitArray Encrypt(BitArray data, BitArray key)
        {
            throw new NotImplementedException();
        }
        public BitArray Decrypt(BitArray data, BitArray key)
        {
            throw new NotImplementedException();
        }

        private BitArray FeistelFunction(BitArray dataRightPart, BitArray key)
        {
            throw new NotImplementedException();
        }
        private BitArray InitialPermute(BitArray data)
        {
            BitArray result = new BitArray(64);

            for (int i = 0; i < 64; ++i)
            {
                result[i] = data[Permutations.initialPermutation[i] - 1];
            }

            return result;
        }
        private BitArray FinalPermute(BitArray data)
        {
            BitArray result = new BitArray(64);

            for (int i = 0; i < 64; ++i)
            {
                result[i] = data[Permutations.finalPermutation[i] - 1];
            }

            return result;
        }
    }
}
