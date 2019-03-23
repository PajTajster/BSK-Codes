using System;
using System.Collections.Generic;
using System.Text;

namespace BSK02.Ciphers
{
    class SSC
    {
        private byte[] polynomial;
        private byte[] seed;
        private byte[] inputX;

        private int outAmount;

        public SSC(string polynomial, string seed, string inputX)
        {
            if(inputX.Contains("test"))
            {
                if (!inputX.Contains(".bin"))
                    inputX += ".bin";
                
                this.inputX = System.IO.File.ReadAllBytes(inputX);               
            }
            else
            {
                this.inputX = new byte[inputX.Length];

                for (int i = 0; i < inputX.Length; ++i)
                {
                    if (inputX[i] == '0')
                    {
                        this.inputX[i] = 0;
                    }
                    if(inputX[i] == '1')
                    {
                        this.inputX[i] = 1;
                    }
                }
            }

            this.polynomial = new byte[polynomial.Length];
            this.seed = new byte[seed.Length];

            for (int i = 0; i < polynomial.Length; ++i)
            {
                if(polynomial[i] == '1')
                {
                    this.polynomial[i] = 1;
                }
                else
                {
                    this.polynomial[i] = 0;
                }
                if (seed[i] == '1')
                {
                    this.seed[i] = 1;
                }
                else
                {
                    this.seed[i] = 0;
                }
            }

            this.outAmount = this.inputX.Length;
        }

        public string Encipher()
        {
            StringBuilder outputY = new StringBuilder();

            int rowLength = polynomial.Length;

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


                if (i < outAmount)
                {
                    outputY.Append(resultXOR ^ inputX[i]);

                    // shift
                    for (int j = 0; j < rowLength - 1; ++j)
                    {
                        bytesArray[i + 1, j + 1] = bytesArray[i, j];
                    }
                    bytesArray[i + 1, 0] = resultXOR;
                }

                bytesToXOR.Clear();
            }

            return outputY.ToString();
        }
    }
}
