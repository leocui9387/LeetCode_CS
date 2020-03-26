using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0371_Sum2Int
    {
        public static void runner()
        {
            List<int[]> tc = new List<int[]>();
            tc.Add(new int[] { 1, 3});
            tc.Add(new int[] { 2, 3});
            tc.Add(new int[] { 8, 10});
            tc.Add(new int[] { 1, 8});
            tc.Add(new int[] { 1, 2});
            tc.Add(new int[] { 20, 30 });


            foreach (int[] c in tc) 
            {
                Console.WriteLine("--CASE: " + c[0] + "||" + c[1]);
                Console.WriteLine(GetSum(c[0], c[1]));
                Console.WriteLine("--END");
            }


        }

        public static int GetSum(int a, int b)
        {

            Console.WriteLine(Convert.ToString(a,2));
            Console.WriteLine(Convert.ToString(b, 2));


            Console.WriteLine("test");
            Console.WriteLine(Convert.ToString( (a & b) << 1, 2));
            Console.WriteLine(Convert.ToString((a ^ b) , 2));
            Console.WriteLine("actual");
            Console.WriteLine(Convert.ToString(a+b, 2));


            int same = (a & b) << 1;
            int diff = (a ^ b);
            if ((same & diff) == 0){
                return diff | same;
            }

            return GetSum(same , diff);
        }

    }
}
