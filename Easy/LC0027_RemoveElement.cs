using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0027_RemoveElement
    {
        public static void runner()
        {
            Dictionary<int, int[]> tc = new Dictionary<int, int[]>();
            tc.Add(3, new int[] { 3, 2, 2, 3 });
            tc.Add(2, new int[] { 0, 1, 2, 2, 3, 0, 4, 2 });
            tc.Add(1, new int[] { 1});
            // tc.Add(new int[] { });

            foreach (KeyValuePair<int, int[]> ia in tc)
            {
                Console.WriteLine("START");
                Console.WriteLine("Result:" + RemoveElement(ia.Value, ia.Key));

                foreach (int i in ia.Value)
                {
                    Console.Write(i + ",");
                }

                Console.WriteLine("END");
            }
        }

        public static int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0) return 0;

            int j = nums.Length - 1;

            while (   j > -1 && nums[j] == val) {j--;}

            int buff;

            for (int i = 0; i < j; i++)
            {
                if (nums[i] == val)
                {
                    
                    buff = nums[j];
                    nums[j] = nums[i];
                    nums[i] = buff;
                    while (nums[j] == val && j > -1) { j--; }
                }

                

            }

            return j + 1;
        }



    }
}
