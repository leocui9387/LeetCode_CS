using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0217_ContainsDups
    {
        public static void runner()
        {

        }


        public bool ContainsDuplicate(int[] nums)
        {

            HashSet<int> hs = new HashSet<int>();

            foreach(int i in nums)
            {
                if (hs.Contains(i)) { return true; }
                hs.Add(i);

            }

            return false;
        }


    }
}
