using System;
using BSK01.Ciphers;

namespace BSK01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
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
            Console.WriteLine("Give string:");
            string textToEncode;
            textToEncode = Console.ReadLine();


            RailFenceCipher rfc = new RailFenceCipher(n);

            string encryptedText = rfc.Encode(textToEncode);

            Console.WriteLine("enkrypszon: " + encryptedText);


            string decodedText = rfc.Decode(encryptedText);

            Console.WriteLine("dekrypszon: " + decodedText);

            Console.ReadKey();
        }


    }
}