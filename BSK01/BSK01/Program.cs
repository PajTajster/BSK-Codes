using System;
using BSK01.Ciphers;

namespace BSK01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, n1;
            Console.WriteLine("Give n:");
            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. rip");
                Console.ReadKey();

                return;
            }
            Console.WriteLine("Give n2: ");
            try
            {
                n1 = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. rip");
                Console.ReadKey();

                return;
            }


            Console.WriteLine("Give string:");
            string textToEncode;
            textToEncode = Console.ReadLine();

            CaesarCipher cc = new CaesarCipher(n, n1);

            RailFenceCipher rfc = new RailFenceCipher(n);

            string encryptedText = cc.Encode(textToEncode);

            Console.WriteLine("enkrypszon: " + encryptedText);


            string decodedText = cc.Decode(encryptedText);

            Console.WriteLine("dekrypszon: " + decodedText);

            Console.ReadKey();
        }


    }
}