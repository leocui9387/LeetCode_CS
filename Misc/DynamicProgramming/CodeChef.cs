using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_CS.Misc.DynamicProgramming
{
    class CodeChef
    {
        public static void min_steps_to_one()
        {
            List<int> tc = new List<int>();
            tc.Add(7);



            foreach(int c in tc)
            {
                Console.WriteLine($"CASE:{c}|");
                Console.WriteLine("Answer:"  + min_steps_to_one1(c));
                Console.WriteLine("END");
            }

        }
        private static int min_steps_to_one1(int n)
        {
            // for positiv int n fewest number of steps to 1 given 3 operations:
            // -1, /2 if even, /3 if divisible by 3

            int[] dp = new int[n + 1];
            

            dp[1] = 0;  // trivial case

            for (int i = 2; i <= n; i++)

            {

                dp[i] = 1 + dp[i - 1];

                if (i % 2 == 0) dp[i] = Math.Min(dp[i], 1 + dp[i / 2]);
                if (i % 3 == 0) dp[i] = Math.Min(dp[i], 1 + dp[i / 3]);

            }
            return dp[n];
        }


    }
}
