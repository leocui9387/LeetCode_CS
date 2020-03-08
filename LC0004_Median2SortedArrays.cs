using System;
using System.Collections.Generic;

namespace LeetCode_CS
{
    class LC0004_Median2SortedArrays
    {
        public static void runner()
        {
            List<String[]> testcase = new List<string[]>();
            Dictionary<String, int[]> cases = new Dictionary<string, int[]>();

            testcase.Add(new String[] { "a1", "a2" });
            cases.Add("a1", new int[] { 1, 3 });
            cases.Add("a2", new int[] { 2 });

            testcase.Add(new String[] { "b1", "b2" });
            cases.Add("b1", new int[] { 1, 2, 3, 4, 4 });
            cases.Add("b2", new int[] { 2, 5, 6 });

            testcase.Add(new String[] { "c1", "c2" });
            cases.Add("c1", new int[] { 1, 2 });
            cases.Add("c2", new int[] { 3, 4 });



            int[] test = new int[] { 1, 3, 5, 7, 9 };
            foreach (int i in test)
            {
                Console.Write(i + "|");
            }
            Console.WriteLine();
            Console.WriteLine();

            foreach (int i in new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })
            {
                Console.WriteLine("int:" + i + "|location:" + binSearch(test, 0, test.Length, i));
                Console.WriteLine();
            }



        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {

            int[] front;
            int[] back;
            // find over lap

            if (nums1[0] > nums2[0])
            {
                front = nums2;
                back = nums1;
            }
            else
            {
                front = nums1;
                back = nums2;
            }

            // location of back[0] in front


            // split between back0 in middle vs after frontEND

            // back0 in middle: cut arrays into sub slices with desired median item no.





            return 0.2;
        }

        private static int binSearch_wHypothetical(int[] p_arr, int p_beg, int p_end, int p_wanted)
        {

            int mid;

            if (p_wanted < p_arr[0]) return -1;
            if (p_wanted > p_arr[p_arr.Length - 1]) return p_arr.Length;


            while (p_beg < p_end)
            {

                Console.WriteLine("beg:" + p_beg + "|end:" + p_end);
                mid = p_beg + (p_end - p_beg) / 2;

                switch (p_arr[mid])
                {
                    case int n when n == p_wanted:
                        return mid;

                    case int n when n > p_wanted:
                        p_end = mid;
                        break;

                    case int n when n < p_wanted:
                        p_beg = mid;
                        break;

                }

                if (p_end == p_beg + 1)
                {
                    if (p_wanted <= p_arr[p_end]) { return p_end; }
                    else { return p_beg; }

                }



            }

            return p_beg;
        }



    }
}
