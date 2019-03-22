using System;
using System.Collections.Generic;
using System.Text;

namespace BSK02.Generators
{
    class LSFRGenerator
    {
        private bool[] polynomial;
        private bool[] seed;
        private int outAmount;

        public LSFRGenerator(string polynomial, string seed, int outAmount)
        {
            this.polynomial = new bool[polynomial.Length];
            this.seed = new bool[seed.Length];

            for(int i = 0; i < polynomial.Length; ++i)
            {
                this.polynomial[i] = polynomial[i] == '1';
                this.seed[i] = seed[i] == '1';
            }
            this.outAmount = outAmount;
        }

        public string[] Generate()
        {
            int rowLength = polynomial.Length;

            string[] generatedBytes = new string[outAmount];

            bool[,] bytesArray = new bool[outAmount + 1, rowLength];

            for (int i = 0; i < rowLength; ++i) 
            {
                bytesArray[0, i] = seed[i];
            }

            List<bool> bytesToXOR = new List<bool>();

            for (int i = 0; i < outAmount + 1; ++i)
            {
                for (int j = 0; j < rowLength; ++j)
                {
                    if (polynomial[j]) 
                    {
                        bytesToXOR.Add(bytesArray[i, j]);
                    }
                }               

                // XOR
                bool resultXOR = bytesToXOR[0];
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
                        if (bytesArray[i + 1, j])
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
