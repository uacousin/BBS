using System;
using System.Numerics;
namespace BBS
{
    class Program
    {
        static void Main(string[] args)
        {
            BBSGenerator generator = new BBSGenerator();
            int quantity = 1000000;
            Console.WriteLine("p = {0}, q = {1}", generator.p, generator.q);
            var time1 = DateTime.Now.TimeOfDay;
            
            byte[] res = generator.nNext_bit(quantity);
            var time = DateTime.Now.TimeOfDay - time1;
            Console.WriteLine("Time: {0},\n Avg: {1}",time, (double)time.TotalMilliseconds/quantity );
            //foreach (var e in res)
              // Console.Write(e+ " ");

            time1 = DateTime.Now.TimeOfDay;
            var bytes = generator.nNext_byte(quantity);
             time = DateTime.Now.TimeOfDay - time1;
            //Console.Write("Bytes: ");
            //foreach(var e in bytes)
            //Console.Write(e+" ");
            Console.WriteLine("Time: {0},\n Avg: {1}", time, (double)time.TotalMilliseconds / quantity);
            Console.ReadKey();
        }
    }
}