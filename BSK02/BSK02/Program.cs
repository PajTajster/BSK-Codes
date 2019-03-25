using System;

using BSK02.Generators;
using BSK02.Ciphers;

namespace BSK02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userInputStrings = new string[3];

            while (true)
            {
                string option = "_";

                Console.WriteLine("1. LSFRGenerator\n" +
                    "2. Synchronous Steam Cipher\n" +
                    "3. Ciphertext Autokey\n" +
                    "4. Exit");
                Console.Write("Option: ");
                option = Console.ReadLine();


                switch(option[0])
                {
                    case '1':
                        {
                            userInputStrings = AskForUserInput(false);
                            LSFRGenerator lsfr = new LSFRGenerator(userInputStrings[0],
                                                                    userInputStrings[1],
                                                                    int.Parse(userInputStrings[2]));

                            string[] output = lsfr.Generate();

                            Console.WriteLine("Generated codes: ");
                            foreach (var item in output)
                            {
                                Console.WriteLine(item);
                            }

                            Console.WriteLine("\nPress any key to continue.");
                            Console.ReadKey(true);
                        }
                        break;
                    case '2':
                        {
                            userInputStrings = AskForUserInput(true);
                            SynchronousStreamCipher ssc = new SynchronousStreamCipher(userInputStrings[0],
                                                                                    userInputStrings[1],
                                                                                    userInputStrings[2]);

                            string output = ssc.Encipher();

                            Console.WriteLine("Enciphered output: " + output);

                            Console.WriteLine("\nDeciphering:");
                            userInputStrings = AskForUserInput(true);
                            ssc = new SynchronousStreamCipher(userInputStrings[0],
                                                            userInputStrings[1],
                                                            userInputStrings[2]);

                            output = ssc.Encipher();

                            Console.WriteLine("Deciphered output: " + output);

                            Console.WriteLine("\nPress any key to continue.");
                            Console.ReadKey(true);
                        }
                        break;
                    case '3':
                        {
                            userInputStrings = AskForUserInput(true);
                            CiphertextAutokey cta = new CiphertextAutokey(userInputStrings[0],
                                                                                    userInputStrings[1],
                                                                                    userInputStrings[2]);

                            string output = cta.Encipher();

                            Console.WriteLine("Enciphered output: " + output);

                            Console.WriteLine("\nDeciphering:");
                            userInputStrings = AskForUserInput(true);
                            cta = new CiphertextAutokey(userInputStrings[0],
                                                            userInputStrings[1],
                                                            userInputStrings[2]);

                            output = cta.Decipher();

                            Console.WriteLine("Deciphered output: " + output);

                            Console.WriteLine("\nPress any key to continue.");
                            Console.ReadKey(true);
                        }
                        break;
                    case '4':
                        return;
                    default:
                        break;
                }
            }
        }

        private static string[] AskForUserInput(bool isCipher)
        {
            string[] output = new string[3];
            bool isCorrectInput = false;

            while (!isCorrectInput)
            {
                Console.WriteLine("Specify polynomial: ");
                output[0] = Console.ReadLine();

                Console.WriteLine("Specify seed:");
                output[1] = Console.ReadLine();

                if(output[0].Length != output[1].Length)
                {
                    Console.WriteLine("Seed and polynomial should be same length!\n\n");
                }
                else
                {
                    isCorrectInput = true;
                }
            }

            if (!isCipher)
            {
                Console.WriteLine("Give n: ");
                output[2] = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Give X [if file type name/path]:");
                output[2] = Console.ReadLine();
            }
            return output;
        }
    }
}
