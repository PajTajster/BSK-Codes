﻿using System;

using BSK02.Generators;

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
            
            Console.WriteLine("Give n: ");
            n = Console.ReadLine();

            LSFRGenerator generator = new LSFRGenerator(outputPoly, outputSeed, int.Parse(n));

            string[] result = generator.Generate();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}