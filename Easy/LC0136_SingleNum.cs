using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0136_SingleNum
    {
        

        public int SingleNumber(int[] nums)
        {

            HashSet<int> testSet = new HashSet<int>();

            foreach (int i in nums)
            {
                if (testSet.Contains(i)) testSet.Remove(i);
                else testSet.Add(i);
            }

            int[] test = new int[1];
            testSet.CopyTo(test);

            return test[0];
        }
    }
}
