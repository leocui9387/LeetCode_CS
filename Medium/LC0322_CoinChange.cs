using System;
using System.Collections.Generic;

namespace LeetCode_CS.Medium
{
    class LC0322_CoinChange
    {
        public static void runner()
        {

            Dictionary<int, int[]> tc = new Dictionary<int, int[]>();

            //tc.Add(11, new int[] { 1, 2, 5 });

            tc.Add(6249, new int[] { 83, 186, 408, 419});

            //tc.Add(25, new int[] {1,5,10,11 });
            //tc.Add(new int[] { });

            foreach (KeyValuePair<int, int[]> c in tc)
            {
                Console.WriteLine("Top Result:" + CoinChange_2(c.Value, c.Key));
            }

        }
        public static int CoinChange_3(int[] coins, int amount)
        {
            // attempt at array based answer with waterfall from largest coin
            int cL = coins.Length;
           
            int[] buff = new int[cL];
            buff[cL - 1] = amount / coins[cL-1];



            return 0;
        }
        private static void cc3_update(int[] p_multiple)
        {
            int i = p_multiple.Length - 1;
            while (p_multiple[i] == 0) i--;


        }

        private static int CC3_value(int[] p_coins, int[] p_multiple)
        {
            int cL = p_coins.Length;
            int result = 0;
            for(int i=0; i<cL; i++) { result += p_coins[i] * p_multiple[i]; }
            return result;
        }

        public static int CoinChange_2(int[] coins, int amount)
        {
            /* brute force for learning
             */
            Console.WriteLine($"Amount:{amount}");
            Utility.PrintIterable<int>(coins);
            if (amount == 0) return 0;
            int cL = coins.Length;
            if (cL == 1)
            {
                if (amount % coins[0] == 0) return amount / coins[0];
                return -1;
            }

            int[] reducedCoins = new int[cL - 1];
            for (int i = 0; i < cL - 1; i++) { reducedCoins[i] = coins[i]; }

            int maxLargest = amount / coins[cL - 1];
            if (maxLargest == 0) return CoinChange_2(reducedCoins, amount);
            
            int result;
            int min = amount / coins[0] + 1;
            for (int i = maxLargest; i >= 0; i--)
            {
                result = CoinChange_2(reducedCoins, amount - i * coins[cL - 1]);
                if (result > -1 && (result + i) < min) min = result + i;
            }

            if (min < amount / coins[0] + 1) return min;
            return -1;
        }

        public static int CoinChange_1(int[] coins, int amount)
        {
            /*
             * ends on the first solution. need to make it so that 
             * it'll keep going until a set max critieria
             */
            Console.WriteLine($"Amount:{amount}");
            Utility.PrintIterable<int>(coins);
            if (amount == 0) return 0;

            int cL = coins.Length;
            if (cL == 0) return -1;

            int[] reducedCoins = new int[cL - 1];
            for (int i = 0; i < cL - 1; i++) { reducedCoins[i] = coins[i]; }

            int maxLargest = amount / coins[cL - 1];

            int result;
            for (int i = maxLargest; i >= 0; i--)
            {
                result = CoinChange_1(reducedCoins, amount - i * coins[cL - 1]);
                if (result > -1) return result + i;
            }

            return -1;

        }

    }
}
