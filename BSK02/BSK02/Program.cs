using System;

using BSK02.Generators;
using BSK02.Ciphers;

namespace BSK02
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPoly = "";
            string outputSeed = "";
            string n = "";


            Console.WriteLine("Give polynomial: ");
            outputPoly = Console.ReadLine();

            Console.WriteLine("Give seed: ");
            outputSeed = Console.ReadLine();
            
            Console.WriteLine("Give X: ");
            n = Console.ReadLine();

            CiphertextAutokey ca = new CiphertextAutokey(outputPoly, outputSeed, n);

            string result = ca.Decipher();

           // SynchronousStreamCipher ssc = new SynchronousStreamCipher(outputPoly, outputSeed, n);
           // string result = ssc.Encipher();

           // LSFRGenerator generator = new LSFRGenerator(outputPoly, outputSeed, int.Parse(n));

           // string[] result = generator.Generate();

            foreach (var item in result)
            {
                Console.Write(item);
            }
        }
    }
}
