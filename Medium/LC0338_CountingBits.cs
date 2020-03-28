using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Medium
{
    class LC0338_CountingBits
    {
        public static void runner()
        {
            List<int> tc = new List<int>();
            tc.Add(5);
            tc.Add(2);
            tc.Add(21);
            //tc.Add();



            foreach (int c in tc)
            {
                Console.WriteLine("CASE:" + c);
                Utility.PrintIterable<int>(CountBits(c));
                Console.WriteLine("END-------");
            }
        }

        public static int[] CountBits(int num)
        {
            int[] final = new int[num+1];

            int i = 1;
            int counter = 1;
            
            while ( i <= num)
            {

                for (int j = 0; j < counter && i <= num; j++, i++)
                {
                    final[i] = 1 + final[j];
                    Console.WriteLine("index: "+ (i) + "|" + final[i]);
                }



                counter *= 2;
            }

            return final;
            
        }

        public static int[] CountBits0(int num)
        {
            List<int> seed = new List<int>();

            seed.Add(0);

            List<int> buff = new List<int>();

            while (seed.Count < num+1 )
            {

                buff.Clear();

                for (int i=0; i < seed.Count && (seed.Count + buff.Count) <= num; i++)
                {
                    buff.Add(1 + seed[i]);
                }

                seed.AddRange(buff);

            }

            return seed.ToArray();
        }
    }
}
