using System;
using System.Collections.Generic;

namespace LeetCode_CS.Easy
{
    class LC0088_MergeSortArray
    {
        public static void runner()
        {
            List<String[]> testcase = new List<string[]>();
            Dictionary<String, inputCase> cases = new Dictionary<string, inputCase>();

            testcase.Add(new String[] { "a1", "a2" });
            cases.Add("a1", new inputCase(new int[] { 1, 2, 3, 0, 0, 0 }, 3));
            cases.Add("a2", new inputCase(new int[] { 2, 5, 6 }, 3));

            testcase.Add(new String[] { "b1", "b2" });
            cases.Add("b1", new inputCase(new int[] { 0 }, 0));
            cases.Add("b2", new inputCase(new int[] { 1 }, 1));

            testcase.Add(new String[] { "c1", "c2" });
            cases.Add("c1", new inputCase(new int[] { 4, 5, 6, 0, 0, 0 }, 3));
            cases.Add("c2", new inputCase(new int[] { 1, 2, 3 }, 3));



            foreach (String[] c in testcase)
            {
                Console.WriteLine("-----new Case");
                Console.Write("case 0:");
                foreach (int i in cases[c[0]].arr)
                {
                    Console.Write(i + "|");
                }
                Console.WriteLine();



                Console.Write("case 1:");
                foreach (int i in cases[c[1]].arr)
                {
                    Console.Write(i + "|");
                }
                Console.WriteLine();


                Merge(cases[c[0]].arr, cases[c[0]].count, cases[c[1]].arr, cases[c[1]].count);

                foreach (int i in cases[c[0]].arr)
                {
                    Console.Write(i + "|");
                }
                Console.WriteLine();

            }








        }

        class inputCase
        {
            public int[] arr;
            public int count;
            public inputCase(int[] p_arr, int p_num)
            {
                arr = p_arr;
                count = p_num;
            }
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // reverse merge sort

            if (n == 0) return;
            while (m > 0 && n > 0)
            {
                if (nums1[m - 1] > nums2[n - 1])
                {
                    nums1[m + n - 1] = nums1[m - 1];
                    m--;
                }
                else
                {
                    nums1[m + n - 1] = nums2[n - 1];
                    n--;
                }

            }

            if (n > 0)
            {
                for (int i = n; i > 0; i--)
                {
                    nums1[i - 1] = nums2[i - 1];
                }

            }



        }
    }
}
