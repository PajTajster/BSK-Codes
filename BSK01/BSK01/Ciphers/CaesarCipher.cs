using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01
{
    class CaesarCipher
    {
        private readonly int letters = 72;
        private readonly int eulerTotient = 24;


        private int key1;
        private int key2;
        public CaesarCipher(int k1, int k2)
        {
            key1 = k1;
            key2 = k2;
        }
        public string Encode(string text)
        {

            return "";
        }

        public string Decode(string text)
        {
            return "";
        }
        int mod(int x, int m)
        {
            int r = x % m;
            return r < 0 ? r + m : r;
        }

    }
}
