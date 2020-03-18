using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS
{
    class LC0035_SearchInsertPosition
    {

        public static void runner()
        {

            int[] tc = new int[] { 1,3,5,6};

            //tc.Add(new String[] { });

            foreach (int i in new int[] {5,2,7,0})
            {
                Console.WriteLine("START----------------");
                Console.Write("Array:");
                foreach(int j in tc)
                {
                    Console.Write(j + ",");
                }
                Console.WriteLine();
                Console.WriteLine("RESULT:" + SearchInsert(tc, i));
                Console.WriteLine("END------------------");
            }
        }

        private static int SearchInsert(int[] nums, int target)
        {
            // optimized
            int p_end = nums.Length - 1;

            if (target <= nums[0]) return 0;
            if (target > nums[p_end]) return p_end + 1;

            int p_beg = 0;
            int mid;

            while (p_beg + 1 < p_end)
            {
                //Console.WriteLine("beg:" + p_beg + "|end:" + p_end);
                mid = p_beg + (p_end - p_beg) / 2;

                if (nums[mid] > target) { p_end = mid; }
                else if (nums[mid] < target) { p_beg = mid; }
                else { return mid; }

            }
            if (target <= nums[p_end]) { return p_end; }

            return p_beg;


        }

        private static int SearchInsert_0(int[] nums, int target)
        {
            // binary search
            int mid;
            int p_beg = 0;
            int p_end = nums.Length - 1;

            if (target <= nums[0]) return 0;
            if (target > nums[nums.Length - 1]) return nums.Length;


            while (p_beg < p_end)
            {

                Console.WriteLine("beg:" + p_beg + "|end:" + p_end);
                mid = p_beg + (p_end - p_beg) / 2;

                switch (nums[mid])
                {
                    case int n when n == target:
                        return mid;

                    case int n when n > target:
                        p_end = mid;
                        break;

                    case int n when n < target:
                        p_beg = mid;
                        break;

                }
                
                if (p_end == p_beg + 1)
                {
                    if (target <= nums[p_end]) { return p_end; }
                    else { return p_beg; }
                }
            }
            return p_beg;
        }
    }

}
