using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0190_ReverseBits
    {
        public static void runner()
        {
            List<uint> tc = new List<uint>();
            tc.Add(5);
            tc.Add(2);
            tc.Add(21);
            //tc.Add();



            foreach (uint c in tc)
            {
                Console.WriteLine("CASE:" + c);
                Console.WriteLine(Convert.ToString(c,2));
                Console.WriteLine(Convert.ToString(reverseBits(c),2));
                Console.WriteLine("END-------");
            }
        }

        public static uint reverseBits(uint n)
        {
            
            uint final = 0;
            for(byte i = 0; i< 32; i++)
            {

                final = final << 1;
                final += n & 1;
                n = n >> 1;
                
            }
            

            return final;

        }

    }
}
