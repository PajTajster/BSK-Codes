using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    static class ICipherHelper
    {
        public static int Modulo(this ICipher cipher, int x, int y)
        {
            int r = x % y;
            return r < 0 ? r + y : r;
        }
    }
}
