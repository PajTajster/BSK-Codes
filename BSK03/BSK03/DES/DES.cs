using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BSK03.DES
{
    class DES
    {
        public bool[] Encrypt(bool[] data, bool[] key)
        {
            KeyGenerator keys = new KeyGenerator(key);

            int extraChunks = 0;
            if(data.Length % 64 != 0)
            {
                extraChunks = data.Length % 64;
            }
            bool[] tmp = data;
            Array.Resize(ref data, data.Length + extraChunks);
            tmp.CopyTo(data, 0);

            var chunks = SplitData(data, 64);

            List<bool[]> connectedBlocks = new List<bool[]>();

            for (int i = 0; i < chunks.Count; ++i)
            {
                var block = chunks[i];
                block = InitialPermute(block);

                bool[] leftBuffer, rightBuffer;

                bool[] leftSplit = new bool[32];
                bool[] rightSplit = new bool[32];

                Array.Copy(block, 0, leftSplit, 0, 32);
                Array.Copy(block, 32, rightSplit, 0, 32);
                leftBuffer = leftSplit;
                rightBuffer = rightSplit;

                for (int j = 0; j < 15; ++j)
                {
                    leftSplit = rightSplit;
                    rightBuffer = FeistelFunction(rightSplit, keys.generatedKeys, i);

                    for (int k = 0; k < 32; ++k)
                    {
                        rightSplit[k] = leftBuffer[k] ^ rightBuffer[k];
                    }
                }

                leftBuffer = leftSplit;
                rightBuffer = FeistelFunction(rightSplit, keys.generatedKeys, 15);
                for (int j = 0; j < 32; ++j)
                {
                    leftSplit[j] = leftBuffer[j] ^ rightBuffer[j];
                }

                Array.Copy(leftSplit, 0, block, 0, 32);
                Array.Copy(rightSplit, 0, block, 32, 32);

                block = FinalPermute(block);

                connectedBlocks.Add(block);
            }

            int outputSize = connectedBlocks.Count * 64;
            outputSize -= extraChunks;

            bool[] output = new bool[outputSize];
            for (int i = 0; i < connectedBlocks.Count - 1; ++i)
            {
                Array.Copy(connectedBlocks[i], 0, output, i * 64, 64);
            }
            Array.Copy(connectedBlocks[connectedBlocks.Count - 1], 0, output, outputSize - 64, 64 - extraChunks);

            return output;
        }
        public bool[] Decrypt(bool[] data, bool[] key)
        {
            KeyGenerator keys = new KeyGenerator(key);

            int extraChunks = 0;
            if(data.Length % 64 != 0)
            {
                extraChunks = data.Length % 64;
            }
            bool[] tmp = data;
            Array.Resize(ref data, data.Length + extraChunks);
            tmp.CopyTo(data, 0);

            var chunks = SplitData(data, 64);

            List<bool[]> connectedBlocks = new List<bool[]>();

            for (int i = 0; i < chunks.Count; ++i)
            {
                var block = chunks[i];
                block = InitialPermute(block);

                bool[] leftBuffer, rightBuffer;

                bool[] leftSplit = new bool[32];
                bool[] rightSplit = new bool[32];

                Array.Copy(block, 0, leftSplit, 0, 32);
                Array.Copy(block, 32, rightSplit, 0, 32);
                leftBuffer = leftSplit;
                rightBuffer = rightSplit;

                for (int j = 15; j > 0; --j)
                {
                    leftSplit = rightSplit;
                    rightBuffer = FeistelFunction(rightSplit, keys.generatedKeys, i);

                    for (int k = 0; k < 32; ++k)
                    {
                        rightSplit[k] = leftBuffer[k] ^ rightBuffer[k];
                    }
                }

                leftBuffer = leftSplit;
                rightBuffer = FeistelFunction(rightSplit, keys.generatedKeys, 0);
                for (int j = 0; j < 32; ++j)
                {
                    leftSplit[j] = leftBuffer[j] ^ rightBuffer[j];
                }

                Array.Copy(leftSplit, 0, block, 0, 32);
                Array.Copy(rightSplit, 0, block, 32, 32);

                block = FinalPermute(block);

                connectedBlocks.Add(block);
            }

            int outputSize = connectedBlocks.Count * 64;
            outputSize -= extraChunks;

            bool[] output = new bool[outputSize];
            for (int i = 0; i < connectedBlocks.Count - 1; ++i)
            {
                Array.Copy(connectedBlocks[i], 0, output, i * 64, 64);
            }
            Array.Copy(connectedBlocks[connectedBlocks.Count - 1], 0, output, outputSize - 64, 64 - extraChunks);

            return output;
        }

        private bool[] FeistelFunction(bool[] dataRightPart, bool[] key, int keyNumber)
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


        private List<bool[]> SplitData(bool[] data, int chunkSize)
        {
            List<bool[]> output = new List<bool[]>();

            for (int i = 0; i < data.Length; i += chunkSize)
            {
                bool[] buffer = new bool[chunkSize];
                Array.Copy(data, i, buffer, 0, chunkSize);

                output.Add(buffer);
            }

            return output;
        }
    }
}
