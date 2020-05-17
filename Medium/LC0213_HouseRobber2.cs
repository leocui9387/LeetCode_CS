using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Medium
{
    public class LC0213_HouseRobber2
    {
        public int Rob(int[] nums)
        {
            // forward prop - 

            int forward = origRob(nums);
            Array.Reverse(nums);
            int back = origRob(nums);


            return Math.Max(forward, back);
        }

        private int origRob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            int[] nMemo = new int[nums.Length];

            nMemo[0] = nums[0];
            nMemo[1] = Math.Max(nums[1], nums[0]);

            int tLength = nums.Length;
            for (int i = 2; i < tLength; i++)
            {
                if (i == 2 && (nums[i] + nMemo[i - 2] > nMemo[i - 1])) tLength--;
                nMemo[i] = Math.Max(nums[i] + nMemo[i - 2], nMemo[i - 1]);
            }

            return nMemo[tLength - 1];
        }
    }
}
