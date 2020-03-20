using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Medium
{
    class LC0238_ProdExceptSelf
    {
        public static void runner()
        {
            List<int[]> tc = new List<int[]>();
            tc.Add(new int[] {1, 2, 3, 4 });
            //tc.Add(new int[] { });


            foreach (int[] c in tc)
            {
                Console.WriteLine();
                Console.Write("Start:");
                foreach (int i in c) { Console.Write(i + ","); }
                Console.WriteLine();
                Console.Write("output:");
                foreach (int i in ProductExceptSelf(c))
                {
                    Console.Write(i + ",");
                }
                Console.WriteLine();
                Console.WriteLine("END");
            }

        }
        private static int[] ProductExceptSelf(int[] nums)
        {

            int nL = nums.Length;
            if (nL < 2) return nums; // creates probablistic outcome that may be up to 95%tile
            int[,] fixs = new int[2,nL];
            int fBuff = 1;
            int bBuff = 1;
            
            for (int i = 0; i<nL; i++)
            {
                fBuff *= nums[i];
                fixs[0,i] = fBuff;
                bBuff *= nums[nL - 1 - i];
                fixs[1,nL - 1 - i] = bBuff;
            }

            for (int i =0; i < nL; i++)
            {
                nums[i] = 1;

                if (i > 0) nums[i] *= fixs[0,i -1];
                if (i < nL-1) nums[i] *= fixs[1, i + 1];
            }

            return nums;
        }
        private static int[] ProductExceptSelf_1(int[] nums)
        {

            //brute force

            int nL = nums.Length;
            int prior = 1;
            int after;
            int buff;

            for (int i =0; i< nL; i++)
            {
                after = 1;
                buff = nums[i];

                for (int j= i + 1; j < nL; j++)
                {
                    after *=nums[j]; 
                }
                nums[i] = prior * after;

                prior *= buff;
                

            }

            return nums;
        }
        private static int[] ProductExceptSelf_0(int[] nums)
        {

            int pi = 1;
            int nL = nums.Length;
            foreach(int i in nums)
            {
                pi *= i;
            }

            for (int i =0; i< nL; i++)
            {
                nums[i] = pi / nums[i];
            }

            return nums;
        }

    }
}
