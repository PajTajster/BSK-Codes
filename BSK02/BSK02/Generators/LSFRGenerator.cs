using System;
using System.Collections.Generic;
using System.Text;

namespace BSK02.Generators
{
    class LSFRGenerator
    {
        private byte[] polynomial;
        private byte[] seed;
        private int outAmount;

        public LSFRGenerator(string polynomial, string seed, int outAmount)
        {
            this.polynomial = new byte[polynomial.Length];
            this.seed = new byte[seed.Length];

            for(int i = 0; i < polynomial.Length; ++i)
            {
                if(polynomial[i] == '1')
                {
                    this.polynomial[i] = 1;
                }
                else
                {
                    this.polynomial[i] = 0;
                }
                if(seed[i] == '1')
                {
                    this.seed[i] = 1;
                }
                else
                {
                    this.seed[i] = 0;
                }
            }
            this.outAmount = outAmount;
        }

        public string[] Generate()
        {
            int rowLength = polynomial.Length;

            string[] generatedBytes = new string[outAmount];

            byte[,] bytesArray = new byte[outAmount + 1, rowLength];

            for (int i = 0; i < rowLength; ++i) 
            {
                bytesArray[0, i] = seed[i];
            }

            List<byte> bytesToXOR = new List<byte>();

            for (int i = 0; i < outAmount + 1; ++i)
            {
                for (int j = 0; j < rowLength; ++j)
                {
                    if (polynomial[j] == 1) 
                    {
                        bytesToXOR.Add(bytesArray[i, j]);
                    }
                }               

                // XOR
                byte resultXOR = bytesToXOR[0];
                for (int k = 1; k < bytesToXOR.Count; ++k)
                    resultXOR ^= bytesToXOR[k];

                if(i < outAmount)
                {
                    // shift
                    for (int j = 0; j < rowLength - 1; ++j)
                    {
                        bytesArray[i + 1, j + 1] = bytesArray[i, j];
                    }
                    bytesArray[i + 1, 0] = resultXOR;


                    for (int j = 0; j < rowLength; ++j)
                    {
                        if (bytesArray[i + 1, j] == 1)
                        {
                            generatedBytes[i] += "1";
                        }
                        else
                        {
                            generatedBytes[i] += "0";
                        }
                    }
                }

                bytesToXOR.Clear();
            }

            return generatedBytes;
        }
    }
}
