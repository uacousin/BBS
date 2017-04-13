using System;

using System.Numerics;
namespace PrimeNumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {


            GostGenerator gostgenerator = new GostGenerator();
            gostgenerator.Generate(1024);
            Console.WriteLine("Done, p = {0}", gostgenerator.p);
            
            
            Console.ReadKey();
        }
    }
}