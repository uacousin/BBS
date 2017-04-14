using System;
using System.Numerics;

namespace BBS
{
    class BBSGenerator
    {
        public BigInteger p;
        public BigInteger q;
        public BigInteger n;
        public BigInteger r;
        public BBSGenerator()
        { // D5BBB96D30086EC484EBA3D7F9CAEB07
            p = BigInteger.Parse("0D5BBB96D30086EC484EBA3D7F9CAEB07", System.Globalization.NumberStyles.AllowHexSpecifier);
            q = BigInteger.Parse("0425D2B9BFDB25B9CF6C416CC6E37B59C1F", System.Globalization.NumberStyles.HexNumber);
            
            n = p * q;
            Random gen = new Random();
            r = BigInteger.Parse(gen.Next(2, Int32.MaxValue).ToString());
        }
        public BigInteger Next()
        {
            r = BigInteger.ModPow(r, 2, n);
            return r;
        }
        public byte Next_bit()
        {
            return (byte)(r % 2);
        }
        public byte Next_byte()
        {
            return (byte)(r % 256);
        }
        public byte[] nNext_byte(int n)
        {
            byte[] res = new byte[n];
            for (int i = 0; i < n; i++)
            {
                this.Next();
                res[i] = Next_byte();
            }
            return res;
        }
       
        public byte[] nNext_bit(int n)
        {
            byte[] res = new byte[n];
            for (int i = 0; i < n; i++)
            {
                this.Next();
                res[i] = Next_bit();
                //Console.WriteLine(i);

            }
            return res;
        }
    }
}


