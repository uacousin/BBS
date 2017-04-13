using System;
using System.Numerics;
using System.Text;

namespace PrimeNumberGenerator
{
    static class  BigIntegerExtentions
    {
        public static byte [] GenerateRandomByteArray(int arrayLength)
        {
            Byte[] bytearray = new Byte[arrayLength];
            Random r = new Random();
            
            r.NextBytes(bytearray);
           
            return bytearray;
            
        }

        public static BigInteger GenerateBigIntByBitLength(int bitlenth)
        {

            var bytearray = GenerateRandomByteArray(bitlenth / 8+1 );
            bytearray[bytearray.Length - 1] = (byte)0x00;
            return new BigInteger(bytearray);
        }

        public static String ToBinaryString (this BigInteger bi)
        {            
            byte[] bytearray = bi.ToByteArray();
            var length = bytearray.Length;

            StringBuilder resultbuilder = new StringBuilder(length * 8+1);
            var binary = Convert.ToString(bytearray[length - 1], 2);

            if (binary[0] != '0'&&bi.Sign == 1)
                resultbuilder.Append("0");

            string temp;

            for (int i= length - 1; i>=0; i--)
            {
                temp = Convert.ToString(bytearray[i], 2);
                resultbuilder.Append(temp.PadLeft(8, '0'));
            }

            return resultbuilder.ToString();

        }


    }
}
