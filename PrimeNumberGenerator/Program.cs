using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
namespace PrimeNumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            int quantity = 10;
            int capacity = 1024;
            
            Console.WriteLine("quantity: {0}, capacity: {1}", quantity, capacity);
            GostGenerator gostgenerator = new GostGenerator();
            var time1 = DateTime.Now.TimeOfDay;
            List<BigInteger> primesByGost = new List<BigInteger>();
            for (int i = 0; i < quantity; i++)
            {
                gostgenerator.Generate(capacity);
                primesByGost.Add(gostgenerator.p);                
            }
            var time = DateTime.Now.TimeOfDay - time1;
            primesByGost.ForEach((x) => { Console.WriteLine(x); });
            Console.WriteLine("Time: {0},\n Avg: {1}", time, (double)time.TotalMilliseconds / quantity);
            Console.WriteLine("Done");
            Console.WriteLine("Parallel");
            primesByGost.Clear();

            time1 = DateTime.Now.TimeOfDay;
            var result = Parallel.For(0, quantity, (x) => { var gg = new GostGenerator(); gg.Generate(capacity); primesByGost.Add(gostgenerator.p); });
            
            while(!result.IsCompleted)
            {
                continue;
            }
            time = DateTime.Now.TimeOfDay - time1;
            Console.WriteLine("Time: {0},\n Avg: {1}", time, (double)time.TotalMilliseconds / quantity);
            //Console.WriteLine(gostgenerator.p.ToBinaryString().Length-8);


            Console.ReadKey();
        }
    }
}