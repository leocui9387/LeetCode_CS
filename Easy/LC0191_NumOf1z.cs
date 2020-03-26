using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0191_NumOf1z
    {
        public static void runner()
        {
            uint[] tc = new uint[] { 3,1,31};
            

            foreach (uint c in tc)
            {
                Console.WriteLine("--CASE: " + c );
                Console.WriteLine(HammingWeight(c));
                Console.WriteLine("--END");
            }

        }

        public static int HammingWeight(uint n)
        {
            int counter = 0;

            while(n != 0)
            {
                if ((n & 1) == 1) counter++;
                n = n >> 1;
            }

            return counter;

        }

    }
}
