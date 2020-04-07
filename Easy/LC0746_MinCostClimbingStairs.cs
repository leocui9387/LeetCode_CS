using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Easy
{
    class LC0746_MinCostClimbingStairs
    {
        public static void runner()
        {
            List<int[]> tc = new List<int[]>();
            tc.Add(new int[] {10, 15, 20});
            tc.Add(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1});
            //tc.Add(new int[] { });
            //tc.Add(new int[] { });
            //tc.Add(new int[] { });

            foreach (int[] c in tc)
            {
                Console.WriteLine($"START");
                Utility.PrintIterable<int>(c);
                Console.WriteLine($"RESULT:" + MinCostClimbingStairs(c));
                Console.WriteLine($"END||");
            }

        }

        public static int MinCostClimbingStairs(int[] cost)
        {
            
            int[] cMemo = new int[cost.Length];

            cMemo[0] = cost[0];
            cMemo[1] = cost[1];

            for (int i = 2; i < cost.Length; i++) 
            {
                cMemo[i] = cost[i] + Math.Min(cMemo[i-2], cMemo[i-1]);
            }

            return Math.Min(cMemo[cost.Length - 2], cMemo[cost.Length - 1]);
        }

    }
}
