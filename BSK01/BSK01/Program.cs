using System;
using BSK01.Ciphers;

namespace BSK01
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;

            Console.WriteLine("Choose alghorithm\n" +
                "1. RailFence\n" +
                "2. Transposition A\n" +
                "3. Transposition B\n" +
                "4. Transposition C\n" +
                "5. Caesar\n" +
                "6. Vigener\n" +
                "7. Exit\n");

            Console.WriteLine("Choose: ");

            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. rip");
                Console.ReadKey();

                return;
            }

            string wordToEncrypt = "";
            Console.WriteLine("Enter your word: ");
            wordToEncrypt = Console.ReadLine();

            switch (option)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                default:
                    break;
            }
            /*
            string key, text;   
            Console.WriteLine("Give text: ");
            text = Console.ReadLine();

            Console.WriteLine("Give key: ");
            key = Console.ReadLine();

            VigenerCipher vc = new VigenerCipher(key);

            string encodedText = vc.Encode(text);

            Console.WriteLine("Encoded text: " + encodedText);

            string decodedText = vc.Decode(text);
            Console.WriteLine("Decoded text: " + decodedText);

            Console.ReadKey();*/
        }


    }
}