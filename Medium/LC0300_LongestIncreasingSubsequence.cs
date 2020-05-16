using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Medium
{
    class LC0300_LongestIncreasingSubsequence
    {
        public static void runner()
        {
            List<int[]> tc = new List<int[]>();
            tc.Add(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });
            //tc.Add(new int[] { });
            //tc.Add(new int[] { });
            //tc.Add(new int[] { });

            foreach (int[] c in tc)
            {
                Console.WriteLine($"START");
                Utility.PrintIterable<int>(c);
                Console.WriteLine($"RESULT:" + LengthOfLIS(c));
                Console.WriteLine($"END||");
            }
        }

        public static int LengthOfLIS(int[] nums) 
        {
            Dictionary<int, SortedSet<int>> val2index = new Dictionary<int, SortedSet<int>>();

            

            return 0;
        }
        public static int LengthOfLIS2(int[] nums)
        {
            // good but not best algo

            if (nums.Length == 0) return 0;
            int[] nMemo = new int[nums.Length];

            nMemo[0] = 1;
            int max = 1;
            int maxBuff;

            for (int i = 1; i < nums.Length; i++)
            {
                maxBuff = 0;
                Console.WriteLine(nums[i] + "|" + nums[i - 1]);

                for (int j = i - 1; maxBuff < j + 1 ; j--) {
                    if (nums[i] > nums[j] && maxBuff < nMemo[j]) 
                    {
                        maxBuff = nMemo[j];
                        if (maxBuff == max) break;
                    } 
                    
                }
                nMemo[i] = maxBuff + 1;
                if (max < nMemo[i]) max = nMemo[i];

                Console.WriteLine(nMemo[i]);
            }

            return max;
        }
        public static int LengthOfLIS1(int[] nums)
        {
            // ignored the fact that it included non-consecutives
            int[] nMemo = new int[nums.Length];

            nMemo[0] = 1;
            int max = 1;

            for (int i = 1; i < nums.Length; i++) 
            {
                Console.WriteLine(nums[i] +"|"+ nums[i - 1]);
                if (nums[i] > nums[i - 1]) 
                {
                    nMemo[i] = nMemo[i - 1] + 1;
                    if (max < nMemo[i]) max = nMemo[i];
                } 
                else nMemo[i] = 1;

                Console.WriteLine(nMemo[i]);
            }

            return max;
        }




    }
}
