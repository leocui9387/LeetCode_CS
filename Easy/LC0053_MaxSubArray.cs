using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0053_MaxSubArray
    {
        public static void runner()
        {
            List<int[]> tc = new List<int[]>();
            tc.Add(new int[] { -2,1 });
            tc.Add(new int[] { -2, -1 });
            tc.Add(new int[] { 1 });
            tc.Add(new int[] { 1,2 });
            tc.Add(new int[] { 2, -1, 1,1 });
            tc.Add(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            
            foreach (int[] test in tc)
            {

                Console.WriteLine("START");

                Console.WriteLine(MaxSubArray(test));

                Console.WriteLine("END");

            }


        }

        public static int MaxSubArray(int[] nums)
        {

            int max = nums[0];
            if (nums.Length == 1) return max;
            int total = 0;
            
            int mPi = nums[0];

            foreach(int i in nums)
            {
                total += i;
                if (i > mPi) mPi = i;

                if (total < 0 )
                {
                    max = total;
                    total = 0;
                    continue;
                }

                if (total > max)
                {
                    max = total;
                    if (total > mPi) mPi = total;
                }

            }
            
            return mPi;
        }

    }
}
