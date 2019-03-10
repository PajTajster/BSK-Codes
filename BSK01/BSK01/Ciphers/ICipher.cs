using System;
using System.Collections.Generic;
using System.Text;

namespace BSK01.Ciphers
{
    interface ICipher
    {
        string Encrypt(string text);
        string Decrypt(string text);
    }
}
