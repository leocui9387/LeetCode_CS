using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0303_RangeSumQueryImmutable
    {
        public static void runner()
        {
            NumArray test = new NumArray(new int[] { -2, 0, 3, -5, 2, -1 });

            foreach((int, int) c in new (int,int)[] {(0,2),(2,5),(0,5)})
            {
                Console.WriteLine($"NEW CASE|1:{c.Item1}|2:{c.Item2}");
                Console.WriteLine(test.SumRange(c.Item1, c.Item2));
                Console.WriteLine("END");


            }



        }

    }

    public class NumArray
    {
        private int[] g_SumMemo;
        private int[] g_nums;
        public NumArray(int[] nums)
        {

            if (nums.Length == 0) 
            {
                g_SumMemo = new int[]{0 };
                return; 
            }

            g_SumMemo = new int[nums.Length];
            g_nums = nums;

            g_SumMemo[0] = nums[0];
            
            for(int i=1; i< nums.Length; i++)
            {
                g_SumMemo[i]= nums[i] + g_SumMemo[i-1];
            }

        }

        public int SumRange(int i, int j)
        {
            if (i == 0) return g_SumMemo[j];
            return g_SumMemo[j] - g_SumMemo[i-1];
        }
    }

    public class NumArray0
    {
        // really bad but simple memoization
        private Dictionary<(int,int), int> g_SumMemo;
        private int[] g_nums;
        public NumArray0(int[] nums)
        {
            g_SumMemo = new Dictionary<(int, int), int>();
            g_nums = nums;



        }

        public int SumRange(int i, int j)
        {
            if (i == j) return g_nums[i];
            if (g_SumMemo.ContainsKey((i,j))) return g_SumMemo[(i,j)];

            int buff = 0;
            for (int k = i; k <= j; k++)
            {
                buff += g_nums[k];
            }
            g_SumMemo.Add((i,j), buff);

            return buff;
        }
    }
}
