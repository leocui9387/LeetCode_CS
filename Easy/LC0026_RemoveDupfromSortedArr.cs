using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0026_RemoveDupfromSortedArr
    {
        public static void runner()
        {
            List<int[]> tc = new List<int[]>();
            tc.Add(new int[] { 1, 1, 2 });
            tc.Add(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 });
            // tc.Add(new int[] { });
            foreach(int[] ia in tc)
            {
                Console.WriteLine("START");
                Console.WriteLine("Result:" + RemoveDuplicates(ia));

                foreach(int i in ia)
                {
                    Console.Write(i + ",");
                }
                
                Console.WriteLine("END");
            }
        }

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int j = 0;
            int buff;
            for(int i=1; i < nums.Length; i++)
            {
                if (nums[i] == nums[j]) continue;

                j++;
                buff = nums[j];
                nums[j] = nums[i];
                nums[i] = buff;

            }

            return j + 1;
        }
    }
}
