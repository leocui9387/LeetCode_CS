﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0268_MissingNumber
    {
        public static void runner()
        {

            List<int[]> tc = new List<int[]>();
            tc.Add(new int[] { 3, 0, 1 });
            tc.Add(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 });

            foreach (int[] test in tc)
            {

                Console.WriteLine("START");
                Console.WriteLine(MissingNumber(test));
                Console.WriteLine("END");

            }

        }
        /*
        public int MissingNumber(int[] nums)
        {

        }
        */
        public static int MissingNumber(int[] nums)
        {
            int nL = nums.Length;
            int total = 0;

            int shouldBe = (nL *10 / 2) * (1 + nL)/10;

            foreach(int n in nums){total += n;}

            Console.WriteLine("total:" + total +"|shouldBe:" + shouldBe);

            return  shouldBe - total ;
        }

    }
}
