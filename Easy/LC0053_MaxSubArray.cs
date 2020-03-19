using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0053_MaxSubArray
    {
        public static void runner()
        {
            List<int[]> tc = new List<int[]>();

            tc.Add(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });



            foreach(int[] test in tc)
            {

                Console.WriteLine("START");


                Console.WriteLine(MaxSubArray(test));

                Console.WriteLine("END");

            }


        }

        public static int MaxSubArray(int[] nums)
        {
            int subsec = 0;
            int largest = nums[0];
            foreach(int i in nums)
            {

                if ( (subsec > -1) == (i > -1) )
                {
                    subsec += i;
                }
                else
                {
                    subsec = i;
                }


                subsec += i;
                Console.WriteLine("i:" + i + "|sub:" + subsec);





            }

            return subsec;
        }

    }
}
