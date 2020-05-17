using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    public class LC0198_HouseRobber
    {

        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            int[] nMemo = new int[nums.Length];

            nMemo[0] = nums[0];
            nMemo[1] = Math.Max(nums[1], nums[0]);

            for (int i = 2; i < nums.Length; i++) 
            {
                nMemo[i] =Math.Max( nums[i] + nMemo[i - 2], nMemo[i - 1] );
            }

            return nMemo[nums.Length -1];
        }

    }
}
