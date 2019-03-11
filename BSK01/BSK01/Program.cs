using System;
using BSK01.Ciphers;

namespace BSK01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose alghorithm\n" +
                "1. RailFence\n" +
                "2. Transposition A\n" +
                "3. Transposition B\n" +
                "4. Transposition C\n" +
                "5. Caesar\n" +
                "6. Vigenere\n" +
                "7. Exit\n");

            Console.WriteLine("Choose: ");

            int option = ReadInt();

            string wordToEncrypt = "";
            Console.WriteLine("Enter your word: ");
            wordToEncrypt = Console.ReadLine();

            ICipher cs = new RailFenceCipher(0);

            switch (option)
            {
                case 1:
                    // RailFence
                    {
                        Console.WriteLine("Give key [Integer]: ");
                        int key = ReadInt();

                        cs = new RailFenceCipher(key);

                        Console.WriteLine("Using RailFence Cipher");
                    }
                    break;
                case 2:
                    // Transposition A
                    {
                        cs = new TranspositionCipherA();

                        Console.WriteLine("Using Transposition A Cipher");
                    }
                    break;
                case 3:
                    // Transposition B
                    {
                        Console.WriteLine("Give key [String, Letters only]: ");
                        string key = Console.ReadLine();

                        cs = new TranspositionCipherB(key);

                        Console.WriteLine("Using Transposition B Cipher");
                    }
                    break;
                case 4:
                    // Transposition C
                    {
                        Console.WriteLine("Give key [String, Letters only]: ");
                        string key = Console.ReadLine();

                        cs = new TranspositionCipherC(key);

                        Console.WriteLine("Using Transposition C Cipher");
                    }
                    break;
                case 5:
                    // Caesar
                    {
                        Console.WriteLine("Give key 1 [Integer]: ");
                        int key0 = ReadInt();

                        Console.WriteLine("Give key 2 [Integer]: ");
                        int key1 = ReadInt();

                        cs = new CaesarCipher(key0, key1);
                        Console.WriteLine("Using Caesar Cipher");
                    }
                    break;
                case 6:
                    // Vigenere
                    {
                        Console.WriteLine("Give key [String, Letters only]: ");
                        string key = Console.ReadLine();

                        cs = new VigenereCipher(key);
                        Console.WriteLine("Using Vigenere Cipher");
                    }
                    break;
                case 7:
                    Console.WriteLine("Bye!");
                    Console.ReadKey();
                    return;
                default:
                    Console.WriteLine("Wrong input!");
                    Console.ReadKey();
                    return;
            }

            Console.WriteLine("\nWord given: " + wordToEncrypt);

            string encryptedWord = cs.Encrypt(wordToEncrypt);
            Console.WriteLine("Encrypted word: " + encryptedWord);

            string decryptedWord = cs.Decrypt(encryptedWord);
            Console.WriteLine("Decrypted word: " + decryptedWord);


            Console.ReadKey();
            return;
        }

        static private int ReadInt()
        {
            int var = 0;

            try
            {
                var = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. rip");
                Console.ReadKey();

                return var;
            }

            return var;
        }

    }
}