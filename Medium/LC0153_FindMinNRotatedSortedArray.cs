using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Medium
{
    class LC0153_FindMinNRotatedSortedArray
    {
        public static void runner()
        {


            List<int[]> tc = new List<int[]>();
            tc.Add(new int[] { 3, 4, 5, 1, 2 });
            tc.Add(new int[] { 4, 5, 6, 7, 0, 1, 2 });
            //tc.Add(new int[] { });

            foreach (int[] c in tc)
            {
                Console.WriteLine("NEW CAST ++++++++++++++++++++");
                Utility.PrintIterable<int>(c);
                Console.WriteLine(FindMin(c));
                Console.WriteLine("END +++++++++++++++++++++++++");
            }


        }

        public static int FindMin(int[] nums)
        {

            int nL = nums.Length;

            int start = 0;
            int end = nL - 1;

            if (nums[start] < nums[end]) return nums[start];

            int mid;

            while (start < end)
            {
                mid = ((end - start) / 2) + start;

                if (nums[mid] > nums[end]) start = mid;
                else end = mid;
                
                if (nums[start] > nums[end]) start++;
                else end--;

                //Console.WriteLine( "s:" + nums[start] + "|m:" + nums[mid] + "|e:" + nums[end]);
            }

            return start;
        }



    }
}
